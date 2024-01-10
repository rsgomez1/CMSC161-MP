using SkeletonEditor;
using UnityEngine;
using UnityEngine.UI;

namespace CarterGames.Assets.LeaderboardManager.Demo
{
    public class ExampleManager : MonoBehaviour
    {
        [SerializeField] private InputField boardID;
        [SerializeField] private InputField playerName;
        [SerializeField] private InputField playerScore;
        
        
        public void AddToBoard()
        {
            if (playerName.text.Length <= 0)
            {
                Debug.Log($"<color=D6BA64><b>Leaderboard Manager Example</b> | Either the name or score fields were blank, please ensure the fields are filled before using this option.</color>");
                return;
            }

            // Convert the savedTime (float) to a double before assigning it to playerScore.text
            float savedTime = TimeSaver.Instance.savedTime;
            double doubleSavedTime = (double)savedTime;

            LeaderboardManager.AddEntryToBoard("Example", playerName.text, doubleSavedTime);
            playerName.text = string.Empty;
            playerScore.text = string.Empty;
        }
        
        public void RemoveFromBoard()
        {
            if (playerName.text.Length <= 0)
            {
                Debug.Log($"<color=D6BA64><b>Leaderboard Manager Example</b> | Either the name or score fields were blank, please ensure the fields are filled before using this option.</color>");
                return;
            }
                
            LeaderboardManager.DeleteEntryFromBoard(boardID.text, playerName.text, double.Parse(playerScore.text));
            playerName.text = string.Empty;
            playerScore.text = string.Empty;
        }

        public void ClearBoard()
        {
            LeaderboardManager.ClearLeaderboard(boardID.text);
        }
    }
}