using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void level1(){
        SceneManager.LoadScene("level1");
    }
    public void level2(){
        SceneManager.LoadScene("level2");
    }
    public void level3(){
        SceneManager.LoadScene("level3");
    }
}
