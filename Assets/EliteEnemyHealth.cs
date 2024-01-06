using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteEnemyHealth : MonoBehaviour
{
    float currentHealth;
    public float maxHealth;
    public Animator animator;
    public GameObject Body;
    public GameObject Jaw;
    public GameObject Sword;

    void Awake()
    {
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
            SoundManager.soundManager.playSkeletonHitSFX();
        }
        Body.GetComponent<FlashSkin>().FlashMaterial();
        Jaw.GetComponent<Flash>().FlashMaterial();
        Sword.GetComponent<Flash>().FlashMaterial();
    }

    void Death()
    {
        animator.SetTrigger("die");
        Destroy(GetComponent<Collider>());
        Destroy(Sword.GetComponent<Collider>());
        SoundManager.soundManager.playSkeletonDeathSFX();
        PlayerInstance.Instance.GetComponent<PlayerMovement>().attackDamage += 3.5f;
    }
}
