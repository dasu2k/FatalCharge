using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public float healthAdd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, PlayerContoller.player.position);
        if(distanceToPlayer < 1.2f)
        {
            PlayerContoller.playerContoller.heal(healthAdd);
            Destroy(gameObject);
        }
    }

    
}
