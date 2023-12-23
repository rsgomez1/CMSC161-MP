using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public string sceneName;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);

            PlayerInstance.Instance.GetComponent<CharacterController>().enabled = false;
            PlayerInstance.Instance.transform.position = new Vector3(166, 3, 97);
            PlayerInstance.Instance.transform.rotation = Quaternion.identity;
            PlayerInstance.Instance.GetComponent<CharacterController>().enabled = true;
            
            PlayerInstance.Instance.GetComponent<CharacterController>().stepOffset = 0.3f;
            PlayerInstance.Instance.GetComponent<CharacterController>().skinWidth = 0.08f;
            PlayerInstance.Instance.GetComponent<CharacterController>().radius = 0.5f;
            PlayerInstance.Instance.GetComponent<CharacterController>().height = 2;
            PlayerInstance.Instance.GetComponent<PlayerMovement>().speed = 9;
            PlayerInstance.Instance.GetComponent<PlayerMovement>().gravity = -18;
            PlayerInstance.Instance.GetComponent<PlayerMovement>().jumpHeight = 1.2f;
            PlayerInstance.Instance.GetComponent<PlayerMovement>().groundDistance = 0.1f;
            PlayerInstance.Instance.GetComponent<Dashing>().dashSpeed = 12;

            PlayerInstance.Instance.transform.Find("Cylinder").localScale = Vector3.one;
            PlayerInstance.Instance.transform.Find("Camera").transform.localPosition = new Vector3(0, 0.6f, 0);
            PlayerInstance.Instance.transform.Find("Camera").GetComponent<Interactor>().InteractRange = 1.2f;
            PlayerInstance.Instance.transform.Find("GroundCheck").transform.localPosition = new Vector3(0, -1, 0);
            PlayerInstance.Instance.transform.Find("Lantern").transform.localPosition = new Vector3(0.3f, -0.27f, 0.4f);
            PlayerInstance.Instance.transform.Find("Lantern").GetComponent<Light>().range = 9;
            PlayerInstance.Instance.transform.Find("Lantern").GetComponent<Light>().intensity = 4.2f;
        }
    }
}
