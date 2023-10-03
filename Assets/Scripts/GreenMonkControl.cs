using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GreenMonkControl : MonoBehaviour
{
    public float health;
    public int damage;
    public float range;
    public float speed;
    public Animator animator;
    public float attackDelay;
    
    void LateUpdate()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(!PauseMenuControl.isPaused)
        {
            //move the enemy towards the player if the player in range of the target
            float distanceToPlayer = Vector3.Distance(transform.position, PlayerContoller.player.position);

            // Check if the player is in range of the target and not too close
            if (distanceToPlayer < range && distanceToPlayer > 2f)
            {
                // Calculate the target position
                Vector3 targetPosition = PlayerContoller.player.position;

                // Clamp the z-position to keep it within the desired range
                targetPosition.z = Mathf.Clamp(targetPosition.z, -0.3f, 0.25f);

                // Move the enemy towards the clamped target position
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                Debug.Log(distanceToPlayer);    
                if(distanceToPlayer < 3f)
                {
                    Debug.Log("health should reduce" );
                    PlayerContoller.playerContoller.takeDamage(0.02f);
                }
            }
            
        }
    }
    public void takeDamage()
    {
        health-=2;
        
        Debug.Log("isHit");
        if(health <= 0 )
        {
            //animator.Play("Dying");
            Destroy(gameObject);
        }
    }

}
