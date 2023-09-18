using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecroControl : MonoBehaviour
{

    public Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //InvokeRepeating("necromancerAttack",4f,3.5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction = PlayerContoller.player.position - transform.position;
        transform.Translate(direction.normalized * 5f * Time.deltaTime);
        //transform.position = Vector3.MoveTowards(transform.position, PlayerContoller.player.position, speed * Time.deltaTime);
    }


    
}
