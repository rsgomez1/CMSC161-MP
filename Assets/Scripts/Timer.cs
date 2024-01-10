using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer Instance;
    TextMeshProUGUI timerText;
    public float startTime;
    bool timerStopped = false;

    private void Awake()
    {
        Instance = this;
        timerText = PlayerInstance.Instance.timerText;
        startTime = Time.time;
        Debug.Log("Timer started");
    }

    // Update is called once per frame
    void Update()
    {
        if (!timerStopped)
        {
            float elapsedTime = Time.time - startTime;

            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
