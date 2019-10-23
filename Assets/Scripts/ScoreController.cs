using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreController : MonoBehaviour {


    public TextMeshProUGUI scoreText;

    GameManager mainGameManager;
    RingSpawnController mainRingSpawnController;

    int score;
    int highScore;

    [SerializeField]
    int[] scoreMileStones;

	void Start () {
        score = 0;
        scoreText.text = "";
        mainGameManager = GetComponent<GameManager>();
        RingController.ringCrossed += IncreaseScore;

        mainRingSpawnController = GetComponent<RingSpawnController>();
        highScore = PlayerPrefs.GetInt("HighScore");
	}
	
    void IncreaseScore()
    {
        if (!mainGameManager.gameOver)
        {
            mainRingSpawnController.DecreaseSpawnDelay();
            score++;
            SetDifficulty();
            scoreText.text = "" + score;
            if(highScore < score)
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
    }

    void SetDifficulty()
    {
        if(score == scoreMileStones[0])
        {
            mainRingSpawnController.MakeRingsSpin();
        }
        else if(score == scoreMileStones[1])
        {
            mainRingSpawnController.MakeRingsSpinOpp();
        }
        else if(score == scoreMileStones[2])
        {
            mainRingSpawnController.MakeRingsSpinRandom();
        }
        else if(score == scoreMileStones[3])
        {
            mainRingSpawnController.IncreaseSpinSpeed();
        }else if(score == scoreMileStones[4])
        {
            mainRingSpawnController.DecreaseSpinSpeed();
        }
    }

}
