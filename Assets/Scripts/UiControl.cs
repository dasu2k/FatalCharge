using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class UiControl : MonoBehaviour
{

    public TMP_Text text ;

    void Update()
    {
        text.text = "health : " + PlayerContoller.health;
    }
}
