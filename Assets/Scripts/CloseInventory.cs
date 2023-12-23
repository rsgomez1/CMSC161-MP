using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseInventory : MonoBehaviour
{
    public void onClick()
    {
        SoundManager.soundManager.playMenuSFX();
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        InventoryManager.Instance.CleanList();
    }
}
