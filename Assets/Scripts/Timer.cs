using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float setTime;
    float remainingTime;

    private void Awake()
    {
        remainingTime = setTime;
        Debug.Log("PTANGENA");
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingTime < 1)
        {
            remainingTime = 0;
            //GameOver script\
            timerText.color = Color.red;
            SceneManager.LoadScene(2);
        } 
        else if (remainingTime > 1)
        {
            remainingTime -= Time.deltaTime;
        }

        Debug.Log(remainingTime);

        //remainingTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
