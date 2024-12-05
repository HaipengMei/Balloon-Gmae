using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isPaused = false;
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                ResumeGame();
            }
            else{
                PauseGame();
            }
        }
    }
    public void PauseGame(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void ResumeGame(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void BackToMain(){
        if (PersistentData.Instance != null)
        {
            PersistentData.Instance.SetDeath(0);

        }
        SceneManager.LoadScene("Main_Menu");
    }
}
