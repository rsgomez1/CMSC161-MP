using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    int currentHealth;
    public int maxHealth;
    public Animator animator;
    public GameObject Body;
    public GameObject Jaw;
    public GameObject Sword;
    public GameObject Shield;

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
        Body.GetComponent<FlashSkin>().FlashMaterial();
        Jaw.GetComponent<Flash>().FlashMaterial();
        Sword.GetComponent<Flash>().FlashMaterial();
        Shield.GetComponent<Flash>().FlashMaterial();
    }

    void Death()
    {
        animator.SetTrigger("die");
        Destroy(GetComponent<Collider>());
        Destroy(Sword.GetComponent<Collider>());
        Destroy(Shield.GetComponent<Collider>());
        SoundManager.soundManager.playSkeletonDeathSFX();
    }
}
