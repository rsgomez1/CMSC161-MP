using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAtStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Save());
    }

    IEnumerator Save()
    {
        yield return new WaitForSeconds(0.5f);
        InventorySaveSystem.Instance.SaveInventory();
    }
}
