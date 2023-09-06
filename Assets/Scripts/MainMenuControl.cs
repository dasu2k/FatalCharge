
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    public void onPlayClick(){
        SceneManager.LoadScene("SampleScene");
    }
}
