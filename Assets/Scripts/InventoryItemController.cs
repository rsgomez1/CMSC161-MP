using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventoryItemController : MonoBehaviour
{
    public GameObject ItemAmount;
    Item item;
    
    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);
        Destroy(gameObject);
    }

    public void UpdateAmount()
    {
        InventoryManager.Instance.Use(item);
        ItemAmount.GetComponent<Text>().text = item.amount.ToString();
    }

    public void UseItem()
    {
        switch (item.id)
        {
            case 2:
                PlayerHealth.Instance.increaseHealth(item.value);
                
                if (item.amount > 1)
                {
                    UpdateAmount();
                } else
                {
                    RemoveItem();
                }
                break;
            default:
                break;
        }
    }
}
