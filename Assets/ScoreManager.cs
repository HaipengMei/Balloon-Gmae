using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public  TextMeshProUGUI levelText;
    int level;
    const int SCORE_FORNEXTLEVEL = 50;
    private int score = 0;
    int point;
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        scoreText.text = "Score: " + score;
        levelText.text = "Level: " + (level+1);
    }
    public void addScore(float ballonSize){
        point = Mathf.Max(1,Mathf.RoundToInt(10/ballonSize));
        score += point;
        scoreText.text = "Score: " + score;
        if (score >= SCORE_FORNEXTLEVEL){
            AdvanceLevel();
        }
            
    }
    public void addScore(int distractor){
        score += distractor;
        scoreText.text = "Score: " + score;
        levelText.text = "Level: " + (level+1);

    }
    private void AdvanceLevel()
    {
        SceneManager.LoadScene(level + 1);
    }
}
