using System.Collections;
using System.Collections.Generic;
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
        int newHealth = currentHealth + health;

        if (newHealth > 100)
        {
            healthBar.setHealth(100);
        } else
        {
            healthBar.setHealth(newHealth);
        }
    }

    void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
    }
}
