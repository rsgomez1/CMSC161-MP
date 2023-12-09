using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidEntrance : MonoBehaviour
{
    public InventoryManager inventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Item item in inventoryManager.Items)
        {
            if (item.id == 1 && item.amount == 5)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
