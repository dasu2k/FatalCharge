using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using Unity.Profiling.LowLevel;

public class UiControl : MonoBehaviour
{
    public static UiControl ui;
    public Image healthBar;
    public TMP_Text prompts;
    float healthToFill;
    void Update()
    {
        healthToFill = PlayerContoller.health/10.0f;
        healthBar.fillAmount =healthToFill;
        ui = this;
    }

    public void prompt(string prmt)
    {
        Debug.Log("trying to promt");
        prompts.text = prmt;
        Invoke("clearPromt",2f);
    }

    void clearPromt()
    {
        prompts.text = "";
    }
}
