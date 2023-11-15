using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour, IInteractable
{
    public void Interact(Collider other)
    {
        PlayerInventory inventory = other.gameObject.GetComponent<PlayerInventory>();

        if (inventory != null )
        {
            inventory.SandGemCollected();
            gameObject.SetActive(false);
        }
    }
}
