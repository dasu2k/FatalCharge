using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Camera cam;
    public int health;
    public int damage;
    public float range;
    public float speed;
    public Animator animator;
    public int attackDelay;

    public GameObject spell;

    
    void Start()
    {
        cam = Camera.main;
        InvokeRepeating("necromancerAttack",4f,3.5f);
    }

    void LateUpdate()
    {
        //bill boarding
        transform.LookAt(PlayerContoller.player.transform,-Vector3.forward);
    }

    void Update(){
        if(!PauseMenuControl.isPaused)
        {
            //move the enemy towards the player if the player in range of the target
            float distanceToPlayer = Vector3.Distance(transform.position, PlayerContoller.player.position);

            // Check if the player is in range of the target and not too close
            if (distanceToPlayer < range && distanceToPlayer > 5f)
            {
                // Calculate the target position
                Vector3 targetPosition = PlayerContoller.player.position;

                // Clamp the z-position to keep it within the desired range
                targetPosition.z = Mathf.Clamp(targetPosition.z, -0.3f, 0.25f);

                // Move the enemy towards the clamped target position
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            }
        }
    }
    
    public void takeDamage()
    {
        health--;
        animator.SetBool("isHit",true);
        Invoke("takingDamageComplete",0.4f);
        //animator.Play("GettingHit");
        if(health <= 0 )
        {
            //animator.Play("Dying");
            Debug.Log("he ded");
            Destroy(gameObject);
        }
    }

    void necromancerAttack()
    {
        if(Vector3.Distance(transform.position , PlayerContoller.player.position) <= range)
        {
            animator.SetBool("isShooting",true);
            Invoke("shootingComplete",1.6f);
            Debug.Log("shot");
            Instantiate(spell,transform.position,Quaternion.identity);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        //if collided with the player 1-give damage to player -> 2.create an explosion -> 3.then destroy self(enemy) 
        if(collision.gameObject.name == "playerCollider")
        {
            PlayerContoller.playerContoller.takeDamage(damage);
            Destroy(gameObject);
        }    
        Debug.Log("hit "+ collision.gameObject.name);
    }

    void shootingComplete(){
        animator.SetBool("isShooting",false);
    }
    void takingDamageComplete()
    {
        Debug.Log("ishit is being set false");
        animator.SetBool("isHit",false);
    }
}

