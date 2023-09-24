using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecroSpell : MonoBehaviour
{
    public float SpellSpeed;
    public int damage;
    void Start()
    {
        // Calculate the direction from the enemy to the player
        Vector3 shootDirection = (PlayerContoller.player.position - transform.position).normalized;

        // Instantiate a bullet prefab
        
        // Get the bullet's Rigidbody2D component and set its velocity
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = shootDirection * SpellSpeed;

        // Destroy the bullet after a certain time (you can adjust this)
        Destroy(gameObject, 2f);
    }

    void OnTriggerEnter(Collider collider){
        Debug.Log(collider.gameObject.name);
        if(collider.gameObject.name == "playerCollider")
        {
            PlayerContoller.playerContoller.takeDamage(damage);
            Destroy(gameObject);
        }
        else if(!(collider.gameObject.name[0] == 'n'))
        {
            Debug.Log(collider.gameObject);
            Destroy(gameObject);
        }
    }
}
