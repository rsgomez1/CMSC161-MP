using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
    private Transform highscoreEntryContainer;
    private Transform highscoreEntryTemplate;
    private void Awake()
    {
        highscoreEntryContainer = transform.Find("highscoreEntryContainer");
        highscoreEntryTemplate = transform.Find("highscoreEntryTemplate");

        highscoreEntryTemplate.gameObject.SetActive(false);

        float templateHeight = 20f;
        for (int i = 0; i < 10; i++)
        {
            Transform entryTransform = Instantiate(highscoreEntryTemplate, highscoreEntryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTransform.gameObject.SetActive(true);

            int rank = i + 1;
            string rankString;
            switch (rank)
            {
                default: rankString = rank + "th"; break;
                case 1: rankString = "1st"; break;
                case 2: rankString = "2nd"; break;
                case 3: rankString = "3rd"; break;
            }

            entryTransform.Find("Rank").GetComponent<Text>().text = rankString;
            int score = Random.Range(0, 1000);
            entryTransform.Find("Time").GetComponent<Text>().text = score.ToString();
            string name = "AAA";
            entryTransform.Find("Name").GetComponent<Text>().text = name;
        }
    }
}
