using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuControl : MonoBehaviour
{
    
    public GameObject pauseMenu;
    public static bool isPaused = false;
    void Start(){
        pauseMenu.SetActive(false);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("pause");
            if(isPaused)
                resume();
            else
                pause();
        }
    }
    public void resume(){
        Time.timeScale = 1.0f;
        isPaused = false;
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    void pause(){
        Time.timeScale = 0f;
        isPaused = true;
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("HomeScreen");
    }
}
