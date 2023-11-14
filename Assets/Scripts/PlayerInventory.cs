using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int numSandGem
    {
        get; private set;
    }

    public void SandGemCollected()
    {
        numSandGem++;
    }
}
