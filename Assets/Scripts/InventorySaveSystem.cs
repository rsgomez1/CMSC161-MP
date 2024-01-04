using System.IO; //For reading and writing
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class InventorySaveSystem : MonoBehaviour
{
    public static InventorySaveSystem Instance;

    private static Dictionary<int, Item> allItemCodes = new Dictionary<int, Item>();

    private static int HashItem(Item item) => Animator.StringToHash(item.itemName);

    const char SPLIT_CHAR = '_';

    private static string FILE_PATH ="NULL!";

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        FILE_PATH = Application.persistentDataPath + "/Inventory.txt";

        CreateItemDictionary();
    }

    private void CreateItemDictionary() 
    {
        Item[] allItems = Resources.FindObjectsOfTypeAll<Item>();

        foreach (Item i in allItems) 
        {
            int key = HashItem(i);

            if (!allItemCodes.ContainsKey(key))
                allItemCodes.Add(key, i);
        }
    }

    public void SaveInventory() 
    {
        PlayerPrefs.SetInt("PlayerHealth", PlayerHealth.Instance.currentHealth);
        PlayerPrefs.SetFloat("PlayerDamage", PlayerInstance.Instance.GetComponent<PlayerMovement>().attackDamage);
        PlayerPrefs.SetInt("hasLantern", boolToInt(InventoryManager.Instance.hasLantern));
        PlayerPrefs.SetInt("hasBoots", boolToInt(InventoryManager.Instance.hasBoots));
        PlayerPrefs.SetInt("hasWeapon", boolToInt(InventoryManager.Instance.hasWeapon));
        PlayerPrefs.SetFloat("movx", PlayerInstance.Instance.gameObject.transform.position.x);
        PlayerPrefs.SetFloat("movy", PlayerInstance.Instance.gameObject.transform.position.y);
        PlayerPrefs.SetFloat("movz", PlayerInstance.Instance.gameObject.transform.position.z);
        PlayerPrefs.SetFloat("rotx", PlayerInstance.Instance.gameObject.transform.rotation.x);
        PlayerPrefs.SetFloat("roty", PlayerInstance.Instance.gameObject.transform.rotation.y);
        PlayerPrefs.SetFloat("rotz", PlayerInstance.Instance.gameObject.transform.rotation.z);

        using (StreamWriter sw = new StreamWriter(FILE_PATH))
        {
            foreach (Item item in InventoryManager.Instance.Items)
            {
                string itemID = HashItem(item).ToString();

                sw.WriteLine(itemID + SPLIT_CHAR + item.amount);                    
            }
        }
    }
        
    private bool InventorySaveExists() 
    {
        if (!File.Exists(FILE_PATH))
        {
            Debug.LogWarning("The file you're trying to access doesn't exist. (Try saving an inventory first).");
            return false;
        }
        return true;
    }
        
    //Delete all items in the inventory. Will be irreversable. Could just create a new file (ie. Change the name of the old save file and create a new one)
    public void ClearInventorySaveFile() 
    {
        if (!InventorySaveExists())
            return;
                
        File.WriteAllText(FILE_PATH, "");//Was previously using String.Empty for the "" empty string but this does not require system namespace
    }

    public void LoadInventory() 
    {
        InventoryManager.Instance.Items.Clear();

        for (int i = InventoryManager.Instance.gameObject.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(InventoryManager.Instance.gameObject.transform.GetChild(i).gameObject);
        }

        PlayerInstance.Instance.GetComponent<PlayerMovement>().enabled = false;
        PlayerInstance.Instance.GetComponent<Dashing>().enabled = false;
        PlayerInstance.Instance.canvas.GetComponent<PauseMenu>().enabled = false;
        PlayerInstance.Instance.canvas.GetComponent<InventoryUI>().enabled = false;
        PlayerInstance.Instance.GetComponent<EnableMouse>().enabled = false;
        PlayerInstance.Instance.GetComponent<CharacterController>().enabled = false;

        PlayerHealth.Instance.currentHealth = PlayerPrefs.GetInt("PlayerHealth");
        PlayerInstance.Instance.GetComponent<PlayerMovement>().attackDamage = PlayerPrefs.GetFloat("PlayerDamage");
        PlayerInstance.Instance.transform.position = new Vector3(PlayerPrefs.GetFloat("movx"), PlayerPrefs.GetFloat("movy"), PlayerPrefs.GetFloat("movz"));
        PlayerInstance.Instance.transform.rotation = new Quaternion(PlayerPrefs.GetFloat("rotx"), PlayerPrefs.GetFloat("roty"), PlayerPrefs.GetFloat("rotz"), 1);
        InventoryManager.Instance.hasLantern = intToBool(PlayerPrefs.GetInt("hasLantern"));
        InventoryManager.Instance.hasBoots = intToBool(PlayerPrefs.GetInt("hasBoots"));
        InventoryManager.Instance.hasWeapon = intToBool(PlayerPrefs.GetInt("hasWeapon"));

        PlayerInstance.Instance.GetComponent<CharacterController>().enabled = true;
        PlayerInstance.Instance.GetComponent<EnableMouse>().enabled = true;
        PlayerInstance.Instance.canvas.GetComponent<InventoryUI>().enabled = true;
        PlayerInstance.Instance.canvas.GetComponent<PauseMenu>().enabled = true;
        PlayerInstance.Instance.GetComponent<Dashing>().enabled = true;
        PlayerInstance.Instance.GetComponent<PlayerMovement>().enabled = true;

        if (!InventorySaveExists())
            return; //Since no save exists, return an empty inventory.

        string line = "";

        using (StreamReader sr = new StreamReader(FILE_PATH)) 
        {
            while ((line = sr.ReadLine()) != null) 
            {
                int key = int.Parse(line.Split(SPLIT_CHAR)[0]);
                Item item = allItemCodes[key];
                item.amount = int.Parse(line.Split(SPLIT_CHAR)[1]);

                Object prefab = AssetDatabase.LoadAssetAtPath("Assets/Resources/" + item.itemName + ".prefab", typeof(GameObject));
                GameObject clone = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
                clone.GetComponent<Item>().amount = item.amount;

                clone.GetComponent<ItemPickup>().Interact();
            }
        }

        return;
    }

    int boolToInt(bool val)
    {
        if (val)
            return 1;
        else
            return 0;
    }

    bool intToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }
}
