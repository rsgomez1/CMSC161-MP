using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInstance : MonoBehaviour
{
    public static PlayerInstance Instance;
    public GameObject canvas;
    public GameObject loader;
    public TextMeshProUGUI timerText;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemySword")
        {
            PlayerHealth.Instance.takeDamage(other.gameObject.GetComponent<EnemyDamage>().attackDamage);
        }
    }
}
