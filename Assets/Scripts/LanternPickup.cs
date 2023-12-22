using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternPickup : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        InventoryManager.Instance.hasLantern = true;
    }
}
