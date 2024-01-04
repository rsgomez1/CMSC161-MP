using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private GameObject loader;

    private void Awake()
    {
        loader = PlayerInstance.Instance.loader;
    }

    public void OnClick()
    {
        LoadScene();
    }

    public async void LoadScene()
    {
        var scene = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        loader.SetActive(true);
        InventorySaveSystem.Instance.LoadInventory();
        await Task.Delay(1500);
        loader.SetActive(false);
    }
}
