using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoarding : MonoBehaviour
{
    private Camera cam;
    void Start()
    {
        cam = Camera.main;
    }

    void LateUpdate()
    {
        //bill boarding
        transform.LookAt(cam.transform,-Vector3.forward);
    }
}
