using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAtStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InventorySaveSystem.Instance.SaveInventory();
    }
}
