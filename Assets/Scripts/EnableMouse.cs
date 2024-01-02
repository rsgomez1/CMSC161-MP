using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMouse : MonoBehaviour
{
    public GameObject inventoryUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!inventoryUI.activeSelf)
            {
                Time.timeScale = 0;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseComponent>().enabled = false;
                Cursor.visible = true;
                gameObject.GetComponent<PlayerMovement>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
                InventoryManager.Instance.ListItems();
            } else
            {
                Time.timeScale = 1;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseComponent>().enabled = true;
                Cursor.visible = false;
                gameObject.GetComponent<PlayerMovement>().enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                InventoryManager.Instance.CleanList();
            }
            
        }
    }
}
