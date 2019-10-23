using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public bool gameOver;
    public bool gameStarted;

    public GameObject gameOverMenu;
    public Animator startButtonAnimator;
    public Animator scoreTextAnimator;
    public TextMeshProUGUI highScoreText;

    private void Start()
    {
        highScoreText.text = ""+PlayerPrefs.GetInt("HighScore");
        if (PlayerPrefs.GetInt("Restart") == 1)
        {
            StartGame();
        }
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverMenu.SetActive(true);
        scoreTextAnimator.SetTrigger("GameEnd");
    }

    public void StartGame()
    {
        gameStarted = true;
        startButtonAnimator.SetBool("gameStarted", true);
    }

    public void RestartGame()
    {
        AdsManager.ShowAd();
    }

    public static void SetRestart()
    {
        PlayerPrefs.SetInt("Restart", 1);
        SceneManager.LoadSceneAsync(0);
    }

    public void ExitGame()
    {
        PlayerPrefs.SetInt("Restart", 0);
        Application.Quit();
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Restart", 0);
    }

    private void OnApplicationPause(bool pause)
    {
        PlayerPrefs.SetInt("Restart", 0);
    }
}
