using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (InventoryManager.Instance.hasLantern)
        {
            gameObject.SetActive(true);
        }
    }
}
