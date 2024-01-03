using System.IO; //For reading and writing
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SimpleInventory 
{
    public class InventorySaveSystem : MonoBehaviour
    {
        private static Dictionary<int, Item> allItemCodes = new Dictionary<int, Item>();

        private static int HashItem(Item item) => Animator.StringToHash(item.itemName);

        const char SPLIT_CHAR = '_';

        private static string FILE_PATH ="NULL!";

        private void Awake()
        {
            FILE_PATH = Application.persistentDataPath + "/Inventory.txt";

            CreateItemDictionary();
        }

        private void OnDisable()
        {
            SaveInventory();
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

        internal List<Item> LoadInventory() 
        {
            List<Item> inventory = new List<Item>();

            if (!InventorySaveExists())
                return inventory; //Since no save exists, return an empty inventory.

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

            return inventory;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Insert))
            {
                SaveInventory();
                Debug.Log("SAVED");
            }
            if (Input.GetKeyDown(KeyCode.Delete))
            {
                LoadInventory();
                Debug.Log("LOADED");
            }
        }
    } 
}
