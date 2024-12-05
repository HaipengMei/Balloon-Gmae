using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersistentData : MonoBehaviour
{
    [SerializeField] int playerDeath;
    private string playerName = "DefaultName"; 
    public InputField nameInputField;

    public static PersistentData Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerName = nameInputField.text;
        playerDeath = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDeath(int s)
    {
        playerDeath = s;
    }

    public void SubmitName()
    {
        playerName = nameInputField.text; 

    }

    public string getName()
    {
        return playerName;
    }

    public int getDeath()
    {
        return playerDeath;
    }
}
