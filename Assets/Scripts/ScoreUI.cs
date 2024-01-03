using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public ScoreRowUI RowUI;
    public ScoreManager ScoreManager;

    private void Start()
    {
        scoreManager.AddScore(new Score(name:"fer", score: 5)
        scoreManager.AddScore(new Score(name:"fer", score: 5)

        var scores = ScoreManager.GetHighScores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
            row.rank.text = (i + 1).ToString();
            row.name.text = scores[i].name; 
            row.score.text = scores[i].score.ToString;
        }
    }
}
