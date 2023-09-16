using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoarding : MonoBehaviour
{
    
    private GameObject player;
    void Start()
    {
        player = Camera.main.transform.parent.gameObject;
    }

    void LateUpdate()
    {
        transform.LookAt(player.transform,-Vector3.forward);
    }
}
