using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Camera cam;
    public int health;
    void Start()
    {
        cam = Camera.main;
    }

    void LateUpdate()
    {
        //bill boarding
        transform.LookAt(cam.transform,-Vector3.forward);
    }

    public void takeDamage()
    {
        if(health > 0)
            health--;
        else
        {
            Debug.Log("he ded");
            Destroy(gameObject);
        }
    }
}
