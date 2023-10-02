using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class NecroControl : MonoBehaviour
{
    public float speed;
    public Animator necroAnimator;
    public GameObject spell;
    public float health;
    public Transform sprite;
    void Start()
    {
        sprite = GetComponentInChildren<Transform>();
        InvokeRepeating("necromancerAttack",3f,2f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPosition = PlayerContoller.player.position;
        targetPosition.z = Mathf.Clamp(targetPosition.z, -2f , -1.56f);
        
        Vector3 playerDirection = PlayerContoller.player.transform.position - transform.position;
        
        float distanceToPlayer = Vector3.Distance(transform.position, PlayerContoller.player.position);
        
        //raycast towards the player
        if(Physics.Raycast(transform.position, playerDirection , out RaycastHit hit)){
            Debug.Log(hit.collider.gameObject.tag);
            
            Debug.DrawRay(transform.position, playerDirection  * hit.distance, Color.yellow);
            if(hit.collider.gameObject.tag == "playerCollider")
            {
                transform.position = Vector3.MoveTowards(transform.position , targetPosition , speed * Time.deltaTime);
            }
        }
        
    }

    void necromancerAttack(){
        float distanceToPlayer = Vector3.Distance(transform.position, PlayerContoller.player.position);
        if(distanceToPlayer < 10f && !necroAnimator.GetBool("isShooting"))
        {
            necroAnimator.SetBool("isShooting", true);
            Invoke("shootingComplete",1.5f);
            Invoke("useSpell",0.8f);
        }
    }
    void useSpell(){
        Instantiate(spell,transform.position,Quaternion.identity);
    }
    void shootingComplete(){
        necroAnimator.SetBool("isShooting",false);
    }
    public void takeDamage()
    {
        health-=2;
        necroAnimator.SetBool("isHit",true);
        Invoke("beingHitComplete",0.4f);
        //animator.Play("GettingHit");
        if(health <= 0 )
        {
            //animator.Play("Dying");
            Destroy(gameObject);
        }
    }
    
    void beingHitComplete()
    {
        necroAnimator.SetBool("isHit",false);
    }
}
