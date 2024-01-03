using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private ScoreData sd;
    private void Awake()
    {
        sd = new ScoreData();
    }

    public IEnumerable<Score> GetHighScores()
    {
        return sd.scores.OrderByDescending(keySelector: x :Score => x.score);
    }

    pulic void AddScore(Score score)
    {
        sd.scores.Add(score);
    }
}
