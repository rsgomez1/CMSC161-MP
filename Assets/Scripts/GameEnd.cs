using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(PlayerInstance.Instance.gameObject);
            Destroy(SoundManager.soundManager.gameObject);
            Destroy(PlayerHealth.Instance.gameObject);
            Destroy(InventoryManager.Instance.gameObject);
            Destroy(InventorySaveSystem.Instance.gameObject);
            SceneManager.LoadScene("GameEnd");
        }
    }
}
