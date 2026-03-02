using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scores;
    private int score;
    private int highScore;
    void Start()
    {
       // todo - sign up for notification about enemy death 
       Enemy.OnEnemyDied += OnEnemyDied;
    }

    private void Update()
    {
        if (Keyboard.current != null && Keyboard.current.lKey.isPressed)
        {
            if (score > highScore)
            {
                highScore = score;
                String highScoreOutput = "";
                if (highScore > 9999)
                {
                    highScoreOutput = "0" + highScore;
                }
                else if (highScore > 999)
                {
                    highScoreOutput = "00" + highScore;
                }
                else if (highScore > 99)
                { 
                    highScoreOutput = "000" + highScore;
                }else if (highScore == 0)
                {
                    highScoreOutput = "00000";
                }
                else
                {
                    highScoreOutput = "0000" + highScore;
                }

                scores.text = "Score   00000    high score: " + highScoreOutput;
            }else{
                String highScoreOutput = "";
                if (highScore > 9999)
                {
                    highScoreOutput = "0" + highScore;
                }
                else if (highScore > 999)
                {
                    highScoreOutput = "00" + highScore;
                }
                else if (highScore > 99)
                { 
                    highScoreOutput = "000" + highScore;
                }else if (highScore == 0)
                {
                    highScoreOutput = "00000";
                }
                else
                {
                    highScoreOutput = "0000" + highScore;
                }

                scores.text = "Score   00000    high score: " + highScoreOutput;
            }

            score = 0;
        }
        String hiScoreOutput = "";
        if (highScore > 9999)
        {
            hiScoreOutput = "0" + highScore;
        }
        else if (highScore > 999)
        {
            hiScoreOutput = "00" + highScore;
        }
        else if (highScore > 99)
        { 
            hiScoreOutput = "000" + highScore;
        }else if (highScore == 0)
        {
            hiScoreOutput = "00000";
        }
        else
        {
            hiScoreOutput = "0000" + highScore;
        }
        String scoreOutput = "";
        if (score > 9999)
        {
            scoreOutput = "0" + score;
        }
        else if (score > 999)
        {
            scoreOutput = "00" + score;
        }
        else if (score > 99)
        { 
           scoreOutput = "000" + score;
        }else if (score == 0)
        {
            scoreOutput = "00000";
        }
        else
        {
            scoreOutput = "0000" + score;
        }
        // Debug.Log("Score   "+scoreOutput+"    high score: " + hiScoreOutput);
        scores.text = "Score   "+scoreOutput+"    high score: " + hiScoreOutput;
    }

    private void OnDestroy()
    {
        Debug.Log("No more points");
        Enemy.OnEnemyDied -= OnEnemyDied;
    }

    void OnEnemyDied(int points)
    {
        Debug.Log(points);
        score += points;
        Debug.Log(score);
       
        //scores.SetText();
    }
}
