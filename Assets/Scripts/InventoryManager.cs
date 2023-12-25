using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();
    public bool hasLantern;
    public bool hasBoots;
    public bool hasWeapon;

    public Transform ItemContent;
    public GameObject InventoryItem;

    public InventoryItemController[] InventoryItems;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    public void Add(Item item)
    {
        bool itemAlreadyInInventory = false;

        foreach (Item inventoryItem in Items)
        {
            if (inventoryItem.id == item.id)
            {
                inventoryItem.amount += item.amount;
                Destroy(item.gameObject);
                itemAlreadyInInventory = true;
            }   
        }

        if (!itemAlreadyInInventory)
        {
            Items.Add(item);
        }
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void Use(Item item)
    {
        item.amount -= 1;
    }

    public void ListItems()
    {
        CleanList();

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemAmount = obj.transform.Find("ItemAmt").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            itemName.text = item.itemName;

            if (item.amount > 1 )
            {
                itemAmount.text = item.amount.ToString();
            } else
            {
                itemAmount.text = "";
            }
            
            itemIcon.sprite = item.icon;
        }

        SetInventoryItems();
    }

    public void CleanList()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
    }

    public void SetInventoryItems()
    {
        InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();

        for (int i = 0; i < Items.Count; i++)
        {
            InventoryItems[i].AddItem(Items[i]);
        }
    }
}
