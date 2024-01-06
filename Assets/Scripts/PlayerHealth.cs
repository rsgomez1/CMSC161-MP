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
    public GameObject gameOverScreen;

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
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Death();
        }
        else
        {
            SoundManager.soundManager.playHitSFX();
        }
    }

    void Death()
    {
        SoundManager.soundManager.playDeathSFX();
        Time.timeScale = 0;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MouseComponent>().enabled = false;
        GameObject.FindGameObjectWithTag("Canvas").GetComponent<InventoryUI>().enabled = false;
        GameObject.FindGameObjectWithTag("Canvas").GetComponent<PauseMenu>().enabled = false;
        PlayerInstance.Instance.gameObject.GetComponent<PlayerMovement>().enabled = false;
        PlayerInstance.Instance.gameObject.GetComponent<EnableMouse>().enabled = false;
        gameOverScreen.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
