using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    int count;
    int currentHealth;
    public int maxHealth;
    public Animator animator;
    public GameObject Sword;
    public GameObject Shield;

    void Awake()
    {
        count = 0;
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Death();
        }
        else
        {
            if (count >= 3)
            {
                SoundManager.soundManager.playBossHurtSFX();
                count = 0;
            } else
            {
                count++;
            }
            SoundManager.soundManager.playSkeletonHitSFX();
        }
    }

    void Death()
    {
        animator.SetTrigger("die");
        Destroy(GetComponent<Collider>());
        Destroy(Sword.GetComponent<Collider>());
        Destroy(Shield.GetComponent<Collider>());
        SoundManager.soundManager.playBossDeathSFX();
    }
}
