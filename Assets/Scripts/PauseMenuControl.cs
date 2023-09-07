using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuControl : MonoBehaviour
{
    public static PauseMenuControl pauseMenuControl;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;

    public static bool isPaused = false;
    void Start(){
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
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
        if(PlayerContoller.health <= 0)
            gameOver();
    }

    
    public void gameOver(){
        pause();
        gameOverMenu.SetActive(true);
    }

    public void resume(){
        Time.timeScale = 1.0f;
        isPaused = false;
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    void  pause(){
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
