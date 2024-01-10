using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextScene : MonoBehaviour
{
    public string sceneName;
    public float movx;
    public float movy;
    public float movz;
    public float rotx;
    public float roty;
    public float rotz;
    private GameObject loader;

    private void Awake()
    {
        loader = PlayerInstance.Instance.loader;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            float elapsed = Time.time - Timer.Instance.startTime;
            Debug.Log("Collision with Player detected. Elapsed time: " + elapsed);
            LoadScene(sceneName);
        }
    }

    public async void LoadScene(string sceneName)
    {
        var scene = SceneManager.LoadSceneAsync(sceneName);
        loader.SetActive(true);
        scene.allowSceneActivation = false;

        PlayerInstance.Instance.GetComponent<PlayerMovement>().enabled = false;
        PlayerInstance.Instance.GetComponent<Dashing>().enabled = false;
        PlayerInstance.Instance.canvas.GetComponent<PauseMenu>().enabled = false;
        PlayerInstance.Instance.canvas.GetComponent<InventoryUI>().enabled = false;
        PlayerInstance.Instance.GetComponent<EnableMouse>().enabled = false;
        PlayerInstance.Instance.GetComponent<CharacterController>().enabled = false;
        PlayerInstance.Instance.transform.position = new Vector3(movx, movy, movz);
        PlayerInstance.Instance.transform.rotation = new Quaternion(rotx, roty, rotz, 1); ;

        scene.allowSceneActivation = true;
        await Task.Delay(1500);

        PlayerInstance.Instance.GetComponent<CharacterController>().enabled = true;
        PlayerInstance.Instance.GetComponent<EnableMouse>().enabled = true;
        PlayerInstance.Instance.canvas.GetComponent<InventoryUI>().enabled = true;
        PlayerInstance.Instance.canvas.GetComponent<PauseMenu>().enabled = true;
        PlayerInstance.Instance.GetComponent<Dashing>().enabled = true;
        PlayerInstance.Instance.GetComponent<PlayerMovement>().enabled = true;

        loader.SetActive(false);
    }
}
