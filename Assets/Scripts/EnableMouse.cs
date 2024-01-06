using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMouse : MonoBehaviour
{
    public GameObject inventoryUI;
    public GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (inventoryUI.activeSelf && !pauseMenu.activeSelf)
            {
                disableM();
                InventoryManager.Instance.CleanList();
            } else
            {
                enableM();
                InventoryManager.Instance.ListItems();
            }
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (pauseMenu.activeSelf && !inventoryUI.activeSelf)
            {
                disableM();
            }
            else
            {
                enableM();                
            }
        }
    }

    public void enableM()
    {
        Time.timeScale = 0;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseComponent>().enabled = false;
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void disableM()
    {
        Time.timeScale = 1;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseComponent>().enabled = true;
        gameObject.GetComponent<PlayerMovement>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
