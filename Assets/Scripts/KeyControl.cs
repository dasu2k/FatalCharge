using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyControl : MonoBehaviour
{
    
    void OnTriggerEnter(Collider collision)
    {
        
        if(collision.gameObject.name == "playerCollider")
        {
            PlayerContoller.playerContoller.hasKey = true;
            UiControl.ui.prompt("You have obtained the key");
            Destroy(gameObject);
        }   
    }
    
}
