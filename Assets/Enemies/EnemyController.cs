using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject Sword;

    public void dealDamageToPlayer()
    {
        if (Sword.TryGetComponent<Collider>(out Collider component) == true)
        {
            component.enabled = true;
        }
    }

    public void noDamageToPlayer()
    {
        Sword.GetComponent<Collider>().enabled = false;
    }

    public void playSlashSFX()
    {
        SoundManager.soundManager.playSlash2SFX();
    }
}
