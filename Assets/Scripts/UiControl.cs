using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class UiControl : MonoBehaviour
{
    public Image healthBar;
    public float healthToFill;
    void Update()
    {
        healthToFill = PlayerContoller.health/10.0f;
        healthBar.fillAmount =healthToFill;
    }
}
