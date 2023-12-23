using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidEntranceSound : MonoBehaviour
{
    Item gem;

    // Update is called once per frame
    void Update()
    {
        foreach (Item item in InventoryManager.Instance.Items)
        {
            if (InventoryManager.Instance.hasLantern && (item.id == 1 && item.amount == 5))
            {
                SoundManager.soundManager.playStoneSlideSFX();
                Destroy(gameObject.GetComponent<PyramidEntranceSound>());
            }
        }
    }
}
