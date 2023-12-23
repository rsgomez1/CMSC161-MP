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
        Instance = this;
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
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            takeDamage(10);
        }
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

    void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
    }
}
