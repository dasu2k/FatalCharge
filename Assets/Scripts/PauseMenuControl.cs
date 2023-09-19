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
        //pausing game but without the pause menu
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;

        //to display the gameover text and the options after game over
        gameOverMenu.SetActive(true);

    }

    public void resume(){
        Time.timeScale = 1.0f;
        isPaused = false;
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("resumed");
    }



    void  pause(){
        Time.timeScale = 0f;
        isPaused = true;
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void goToMainMenu()
    {
        SceneManager.LoadScene("HomeScreen");
    }

}
