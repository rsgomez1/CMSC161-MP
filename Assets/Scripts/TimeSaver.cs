using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSaver : MonoBehaviour
{
    public static TimeSaver Instance;
    public float savedTime;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
