using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public GameObject Sword;

    public void dealDamageToPlayer()
    {
        Sword.GetComponent<Collider>().enabled = true;
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
