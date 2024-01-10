using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Score
{
    public string playername;
    public float score;

    public Score(string name, float score)
    {
        this.playername = name;
        this.score = score;
    }
}  
