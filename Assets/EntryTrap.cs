using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryTrap : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<MeshCollider>().isTrigger = false;

        }
    }
}
