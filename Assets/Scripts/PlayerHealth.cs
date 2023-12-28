using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void increaseHealth(int health)
    {
        if (currentHealth + health > 100)
        {
            currentHealth = 100;
            
        } else
        {
            currentHealth += health;
        }

        healthBar.setHealth(currentHealth);
    }

    public void takeDamage(int damage)
    {
        SoundManager.soundManager.playHitSFX();
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
    }
}
