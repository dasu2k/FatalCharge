
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{

    void Start(){
        Time.timeScale = 1f;
    }
    public void onPlayClick(){
        SceneManager.LoadScene("level1");
    }
}
