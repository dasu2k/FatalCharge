using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PortalControl : MonoBehaviour
{
    void OnTriggerEnter(Collider collision){
        Debug.Log(SceneManager.GetActiveScene().name);
        if(SceneManager.GetActiveScene().name == "level2")
            SceneManager.LoadScene("HomeScreen");
        else if(SceneManager.GetActiveScene().name == "level1")
            SceneManager.LoadScene("level2");
        Cursor.lockState = CursorLockMode.None;
    }
}
