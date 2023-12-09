using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour, IInteractable
{
    public Item Item;

    public void Interact()
    {
        SoundManager.soundManager.playPickupSFX();
        InventoryManager.Instance.Add(Item);
        gameObject.SetActive(false);
    }
}
