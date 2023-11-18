using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    private void Awake()
    {
        Instance = this;
    }
    
    public void Add(Item item)
    {
        bool itemAlreadyInInventory = false;

        foreach (Item inventoryItem in Items)
        {
            if (inventoryItem.id == item.id)
            {
                inventoryItem.amount += item.amount;
                itemAlreadyInInventory = true;
            }   
        }

        if (!itemAlreadyInInventory)
        {
            Items.Add(item);
        }
    }

    /*public void Remove(Item item)
    {
        Items.Remove(item);
    }*/

    public void ListItems()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

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
    }
}
