using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceSound : MonoBehaviour
{
    public int Level;
    Item gem;

    // Update is called once per frame
    void Update()
    {
        foreach (Item item in InventoryManager.Instance.Items)
        {
            if (Level == 1 && InventoryManager.Instance.hasLantern && (item.id == 1 && item.amount == 5))
            {
                SoundManager.soundManager.playStoneSlideSFX();
                Destroy(gameObject.GetComponent<EntranceSound>());
            }
            if (Level == 2 && InventoryManager.Instance.hasBoots && (item.id == 4 && item.amount == 5))
            {
                SoundManager.soundManager.playStoneSlideSFX();
                Destroy(gameObject.GetComponent<EntranceSound>());
            }
            if (Level == 3 && InventoryManager.Instance.hasWeapon && (item.id == 6 && item.amount == 5))
            {
                SoundManager.soundManager.playStoneSlideSFX();
                Destroy(gameObject.GetComponent<EntranceSound>());
            }
        }
    }
}
