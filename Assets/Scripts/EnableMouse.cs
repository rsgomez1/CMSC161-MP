using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMouse : MonoBehaviour
{
    public GameObject inventoryUI;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!inventoryUI.activeSelf)
            {
                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                InventoryManager.Instance.ListItems();
            } else
            {
                Time.timeScale = 1;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            
        }
    }
}
