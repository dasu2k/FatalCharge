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
    public Animator animator;

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
        //animator.SetBool("isHit",false);
    }
    
    public void takeDamage()
    {
        health--;
        //animator.SetBool("isHit",true);
        if(health <= 0 )
        {
            Debug.Log("he ded");
            Instantiate(explosion, transform.position , transform.rotation);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        //if collided with the player 1-give damage to player -> 2.create an explosion -> 3.then destroy self(enemy) 
        if(collision.gameObject.name == "playerCollider")
        {
            PlayerContoller.playerContoller.takeDamage(damage);
            Instantiate(explosion,transform.position,transform.rotation);
            Destroy(gameObject);
        }    
        Debug.Log("hit "+ collision.gameObject.name);
    }
}

