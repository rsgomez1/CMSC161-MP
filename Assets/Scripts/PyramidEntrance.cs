using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidEntrance : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Item item in InventoryManager.Instance.Items)
        {
            if (item.id == 1 && item.amount == 5)
            {
                SoundManager.soundManager.playStoneSlideSFX();
                Destroy(gameObject);
            }
        }
    }
}
