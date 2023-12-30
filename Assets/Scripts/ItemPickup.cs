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
        gameObject.transform.parent = InventoryManager.Instance.gameObject.transform;
        gameObject.SetActive(false);

        switch (Item.id)
        {
            case 3:
                InventoryManager.Instance.hasLantern = true;
                break;
            case 5:
                InventoryManager.Instance.hasBoots = true;
                break;
            default:
                break;
        }     
    }
}
