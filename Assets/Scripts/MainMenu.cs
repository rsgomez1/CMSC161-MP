using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
    public void LeaderBoards()
    {
        SceneManager.LoadScene("LeaderboardBack");
    }

    public void LeaderBoardBack()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Menu()
    {
        Destroy(TimeSaver.Instance.gameObject);
        SceneManager.LoadScene("Menu");
    }
}
