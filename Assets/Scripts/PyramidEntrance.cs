using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidEntrance : MonoBehaviour
{
    public GameObject Block;
    public GameObject moveToObject;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        foreach (Item item in InventoryManager.Instance.Items)
        {
            if (InventoryManager.Instance.hasLantern && (item.id == 1 && item.amount == 5))
            {
                Block.transform.position = Vector3.MoveTowards(Block.transform.position, moveToObject.transform.position, speed);
            }
        }
    }
}
