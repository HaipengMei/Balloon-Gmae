using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
public class ScoreManage : MonoBehaviour
{
    [SerializeField]  TextMeshProUGUI ScoreText;
    [SerializeField]  TextMeshProUGUI levelText;
    [SerializeField]  TextMeshProUGUI nameText;
    [SerializeField]  TextMeshProUGUI DeathText;
    [SerializeField]  TextMeshProUGUI restartMessage;
    const int ScoreForNextLevel = 50;
    private int score = 0;
    int point;
    private static int currentLevelIndex;
    private string[] levels = { "level1", "level2", "level3" ,"level4"};
    void Start()
    {
        if (currentLevelIndex == 0){
        currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        }
        if (SceneManager.GetActiveScene().name == "level1"){
        currentLevelIndex = 1;
        }
        if (SceneManager.GetActiveScene().name == "level2"){
        currentLevelIndex = 2;
        }
        if (SceneManager.GetActiveScene().name == "level13"){
        currentLevelIndex = 3;
        }
        if (SceneManager.GetActiveScene().name == "level14"){
        currentLevelIndex = 4;
        }
        UpdateUI();
        DisplayName();
        DisplayDeath();
        InvokeRepeating("CheckBalloons", 1f, 1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (score >= ScoreForNextLevel)
    {
        NextLevel();
    }
    }
    public void addScore(float ballonSize){
        point = Mathf.Max(1,Mathf.RoundToInt(20/ballonSize));
        score += point;
        UpdateUI();


    }
    public void minuesScore(float distractor){
        point = Mathf.Max(1,Mathf.RoundToInt(10/distractor));
        score -= point;
        UpdateUI();
    }
    void NextLevel(){
        if (currentLevelIndex < levels.Length){
        SceneManager.LoadScene(levels[currentLevelIndex]);
        currentLevelIndex++;
        score = 0; 
    }
    }
    void UpdateUI()
    {
        ScoreText.text = "Score: " + score;
        levelText.text = "Level: " + currentLevelIndex;
    }
    void CheckBalloons()
    {
        GameObject[] balloons = GameObject.FindGameObjectsWithTag("Balloon");
        if (balloons.Length == 0 && score < ScoreForNextLevel){
            RestartLevel();
        }
    }
    void RestartLevel()
    {
        PersistentData.Instance.SetDeath(PersistentData.Instance.getDeath()+1);
        restartMessage.text = "Not enough points! Restarting level...";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }
    void DisplayName(){
        nameText.text = "Hi, " + PersistentData.Instance.getName() + "!";
    }
    void DisplayDeath(){
        DeathText.text = "Deaths: " + PersistentData.Instance.getDeath();
    }


}