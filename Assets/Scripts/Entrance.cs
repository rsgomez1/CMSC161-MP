using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    public int Level;
    public GameObject Block;
    public GameObject moveToObject;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        foreach (Item item in InventoryManager.Instance.Items)
        {
            if (Level == 1 && InventoryManager.Instance.hasLantern && (item.id == 1 && item.amount == 5))
            {
                Block.transform.position = Vector3.MoveTowards(Block.transform.position, moveToObject.transform.position, speed);
            }
            if (Level == 2 && InventoryManager.Instance.hasBoots && (item.id == 4 && item.amount == 5))
            {
                Block.transform.position = Vector3.MoveTowards(Block.transform.position, moveToObject.transform.position, speed);
            }
            if (Level == 3 && InventoryManager.Instance.hasWeapon && (item.id == 6 && item.amount == 5))
            {
                Block.transform.position = Vector3.MoveTowards(Block.transform.position, moveToObject.transform.position, speed);
            }
        }
    }
}
