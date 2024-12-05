using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//List for save BestPlayerRank

public class GameCompletionManager : MonoBehaviour
{
    [SerializeField] const int MaxPlayersForRank = 5;
    [SerializeField] const string NAME_KEY = "HighScoreName:";
    [SerializeField] const string Death_KEY = "Death:";

    [SerializeField] string playerName;
    [SerializeField] int playerDeaths;
    [SerializeField] TextMeshProUGUI[] nameTexts;
    [SerializeField] TextMeshProUGUI[] DeathTexts;

    void Start()
    {
        playerName = PersistentData.Instance.getName();
        playerDeaths = PersistentData.Instance.getDeath();

    }

    // Save data by PlayerPrefs, the sorted it by who has less death
    private void SaveScore()
    {
        for (int i = 0; i < MaxPlayersForRank; i++)
        {
            string currentNameKey = NAME_KEY + i;
            string currentDeathKey = Death_KEY  + i;

            { 
                if (PlayerPrefs.HasKey(currentDeathKey))
                {
                    int currentDeath = PlayerPrefs.GetInt(currentDeathKey);
                    if (playerDeaths < currentDeath)
                    {
                        int tempScore = currentDeath;
                        string tempName = PlayerPrefs.GetString(currentNameKey);

                        PlayerPrefs.SetString(currentNameKey, playerName);
                        PlayerPrefs.SetInt(currentDeathKey, playerDeaths);

                        playerDeaths = tempScore;
                        playerName = tempName;
                    }

                }
                else
                {
                    PlayerPrefs.SetString(currentNameKey, playerName);
                    PlayerPrefs.SetInt(currentDeathKey, playerDeaths);
                    return;
                }
            }
        }
    }
        
    public void DisplayHighScores()
    {    
        for (int i = 0; i < MaxPlayersForRank; i++)
        {
            nameTexts[i].text = PlayerPrefs.GetString(NAME_KEY+i);
            DeathTexts[i].text = PlayerPrefs.GetInt(Death_KEY+i).ToString();
        }
    }
    //Public method used for button, when clicked clean all previous rank history
    public void ClearAllData()
    {
    PlayerPrefs.DeleteAll();
    PlayerPrefs.Save(); 
}
}
