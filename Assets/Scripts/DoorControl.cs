using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DoorControl : MonoBehaviour
{

    // Start is called before the first frame update
    float distanceToPlayer;
    private Collider2D coll;
    public bool keyNeeded;
    private bool isOpening;
    public TMP_Text prompt;
    void Start()
    {
        coll = GetComponent<Collider2D>();
        
        float distanceToPlayer = Vector3.Distance(transform.position,PlayerContoller.player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position,PlayerContoller.player.transform.position);
        if((Input.GetKeyDown(KeyCode.Space) && distanceToPlayer < 3f) || isOpening)
        {
            if(keyNeeded && !PlayerContoller.playerContoller.hasKey)
            {
                UiControl.ui.prompt("You need a key to unlock this door");
            }
            else{
                isOpening = true;
            }
            if(isOpening)
            {
                transform.position = Vector3.MoveTowards(transform.position ,new Vector3(transform.position.x,transform.position.y,0.93f) , 0.1f);
                coll.enabled = false;
            }
        }
    }
}
