using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Camera cam;
    public int health;
    public int damage;
    public float range;
    public float speed;
    public GameObject explosion;
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
            //move the enemy towards the player if the player in range of the target
            if(Vector3.Distance(transform.position , PlayerContoller.player.position) < range)
                transform.position = Vector3.MoveTowards(transform.position , PlayerContoller.player.position, speed* Time.deltaTime);
        }
    }
    
    public void takeDamage()
    {
        health--;

        if(health <= 0 )
        {
            Debug.Log("he ded");
            //Instantiate(explosion, transform.position , transform.rotation);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "playerCollider")
        {
            Destroy(gameObject);
            PlayerContoller.takeDamage(damage);
        }    
        Debug.Log("hit "+ collision.gameObject.name);
    }
}

