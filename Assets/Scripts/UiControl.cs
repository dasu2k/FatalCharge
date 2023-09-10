using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class UiControl : MonoBehaviour
{
    public Slider health;
    void Update()
    {
        health.value = PlayerContoller.health;
    }
}
