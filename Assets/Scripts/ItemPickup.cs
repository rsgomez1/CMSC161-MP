using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour, IInteractable
{
    public Item Item;

    public void Interact()
    {
        InventoryManager.Instance.Add(Item);
        Destroy(gameObject);
    }
}
