using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{
    public void BackToMenu()
    {
        Time.timeScale = 1;
        Destroy(PlayerInstance.Instance.gameObject);
        Destroy(SoundManager.soundManager.gameObject);
        Destroy(PlayerHealth.Instance.gameObject);
        Destroy(InventoryManager.Instance.gameObject);
        Destroy(InventorySaveSystem.Instance.gameObject);
        SceneManager.LoadScene("Menu");
    }
}
