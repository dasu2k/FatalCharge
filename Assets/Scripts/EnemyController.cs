using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Camera cam;
    public int health;

    public int damage;
    void Start()
    {
        cam = Camera.main;
    }

    void LateUpdate()
    {
        //bill boarding
        transform.LookAt(cam.transform,-Vector3.forward);
    }

    void Update(){
        if(!PauseMenuControl.isPaused)
        {
            transform.position = Vector3.MoveTowards(transform.position , PlayerContoller.player.position, .004f);
        }
    }
    
    public void takeDamage()
    {
        health--;

        if(health <= 0 )
        {
            Debug.Log("he ded");
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        PlayerContoller.takeDamage(damage);
        
    }
}

