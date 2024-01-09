using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float startTime;
    bool timerStopped = false;

    private void Start()
    {
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.CompareTag("Collider"))
        {
            timerStopped = true;
            float elapsed = Time.time - startTime;
            Debug.Log("Collision with Player and Collider detected. Elapsed time: " + elapsed);
            // Use the elapsed time for any specific action you need
        }
        else if (other.CompareTag("Player"))
        {
            float elapsed = Time.time - startTime;
            Debug.Log("Collision with Player detected. Elapsed time: " + elapsed);
        }
        else if (other.CompareTag("Collider"))
        {
            float elapsed = Time.time - startTime;
            Debug.Log("Collision with Collider detected. Elapsed time: " + elapsed);
        }
    }
}
