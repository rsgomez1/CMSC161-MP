using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    int currentHealth;
    public int maxHealth = 100;
    public Animator animator;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Death();
        } else
        {
            SoundManager.soundManager.playSkeletonHitSFX();
        }
    }

    void Death()
    {
        animator.SetTrigger("die");
        GetComponent<Collider>().enabled = false;
        SoundManager.soundManager.playSkeletonDeathSFX();
    }
}
