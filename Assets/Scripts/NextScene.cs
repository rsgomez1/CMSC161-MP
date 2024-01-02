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
            LoadScene(sceneName);
        }
    }

    public async void LoadScene(string sceneName)
    {
        var scene = SceneManager.LoadSceneAsync(sceneName);
        loader.SetActive(true);

        PlayerInstance.Instance.GetComponent<PlayerMovement>().enabled = false;
        PlayerInstance.Instance.GetComponent<Dashing>().enabled = false;
        PlayerInstance.Instance.canvas.GetComponent<InventoryUI>().enabled = false;
        PlayerInstance.Instance.GetComponent<EnableMouse>().enabled = false;
        PlayerInstance.Instance.GetComponent<CharacterController>().enabled = false;
        PlayerInstance.Instance.transform.position = new Vector3(movx, movy, movz);
        PlayerInstance.Instance.transform.rotation = new Quaternion(rotx, roty, rotz, 1); ;

        if (sceneName == "Level2")
        {
            PlayerInstance.Instance.GetComponent<CharacterController>().skinWidth = 0.08f;
            PlayerInstance.Instance.GetComponent<CharacterController>().radius = 0.5f;
            PlayerInstance.Instance.GetComponent<CharacterController>().height = 2;
            PlayerInstance.Instance.GetComponent<CharacterController>().stepOffset = 0.45f;
            PlayerInstance.Instance.GetComponent<CapsuleCollider>().radius = 0.69f;
            PlayerInstance.Instance.GetComponent<CapsuleCollider>().height = 2.15f;
            PlayerInstance.Instance.GetComponent<PlayerMovement>().speed = 9;
            PlayerInstance.Instance.GetComponent<PlayerMovement>().gravity = -18;
            PlayerInstance.Instance.GetComponent<PlayerMovement>().jumpHeight = 1.8f;
            PlayerInstance.Instance.GetComponent<PlayerMovement>().groundDistance = 0.1f;
            PlayerInstance.Instance.GetComponent<Dashing>().dashSpeed = 15;

            PlayerInstance.Instance.transform.Find("Cylinder").localScale = Vector3.one;
            PlayerInstance.Instance.transform.Find("Camera").transform.localPosition = new Vector3(0, 0.6f, 0);
            PlayerInstance.Instance.transform.Find("Camera").GetComponent<Interactor>().InteractRange = 1.8f;
            PlayerInstance.Instance.transform.Find("Camera").transform.Find("Arms").localScale = new Vector3(2.5f, 1.8f, 2.5f);
            PlayerInstance.Instance.transform.Find("GroundCheck").transform.localPosition = new Vector3(0, -1, 0);
            PlayerInstance.Instance.transform.Find("Lantern").transform.localPosition = new Vector3(0.3f, -0.27f, 0.4f);
            PlayerInstance.Instance.transform.Find("Lantern").GetComponent<Light>().range = 9;
            PlayerInstance.Instance.transform.Find("Lantern").GetComponent<Light>().intensity = 4.2f;
        }

        await Task.Delay(1500);

        PlayerInstance.Instance.GetComponent<CharacterController>().enabled = true;
        PlayerInstance.Instance.GetComponent<EnableMouse>().enabled = true;
        PlayerInstance.Instance.canvas.GetComponent<InventoryUI>().enabled = true;
        PlayerInstance.Instance.GetComponent<Dashing>().enabled = true;
        PlayerInstance.Instance.GetComponent<PlayerMovement>().enabled = true;

        loader.SetActive(false);
    }
}
