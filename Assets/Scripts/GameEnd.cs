using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    private GameObject loader;

    private void Awake()
    {
        loader = PlayerInstance.Instance.loader;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LoadScene("GameEnd");
        }
    }

    public async void LoadScene(string sceneName)
    {
        var scene = SceneManager.LoadSceneAsync(sceneName);
        loader.SetActive(true);
        Destroy(PlayerInstance.Instance.gameObject);
        Destroy(SoundManager.soundManager.gameObject);
        Destroy(PlayerHealth.Instance.gameObject);
        Destroy(InventoryManager.Instance.gameObject);
        Destroy(InventorySaveSystem.Instance.gameObject);
        await Task.Delay(1500);
        loader.SetActive(false);
    }
}
