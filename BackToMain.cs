
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMain : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void WantBackToMain(){
         SceneManager.LoadScene("Main_Menu");
    }
}
