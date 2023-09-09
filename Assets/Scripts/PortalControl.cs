using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PortalControl : MonoBehaviour
{


    void OnTriggerEnter(Collider collision){
        Debug.Log("entered portal");
        SceneManager.LoadScene("HomeScreen");
        Cursor.lockState = CursorLockMode.None;
    }
}
