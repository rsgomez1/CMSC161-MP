using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    int count;
    float currentHealth;
    public float maxHealth;
    public Animator animator;
    public GameObject Sword;
    public GameObject Shield;
    public GameObject GameExit;

    void Awake()
    {
        count = 0;
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
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
        Destroy(GameExit);
        SoundManager.soundManager.playBossDeathSFX();
    }
}
