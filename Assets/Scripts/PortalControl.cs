using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PortalControl : MonoBehaviour
{
    void OnTriggerEnter(Collider collision){
        Debug.Log(SceneManager.GetActiveScene().name);

        if(collision.gameObject.name == "playerCollider")
        {
            if(SceneManager.GetActiveScene().name == "level2")
                SceneManager.LoadScene("levelSelector");
            else if(SceneManager.GetActiveScene().name == "level1")
                SceneManager.LoadScene("levelSelector");
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
