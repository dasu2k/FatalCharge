using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    // Start is called before the first frame update
    public float sens;
    public Camera mainCam;
    public Animator camAnimator;
    public Rigidbody2D rb;
    public float speed = 10f;
    void Start()
    {
        sens = 3f;
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal") , Input.GetAxis("Vertical"));
        //mouse input stuff
        mainCam.transform.Rotate(-sens*(Input.GetAxis("Mouse Y")) , 0 , 0 , Space.Self);
        transform.Rotate(0,sens*(Input.GetAxis("Mouse X")),0,Space.Self);
        
        //player movement
        if(input != Vector2.zero)
        {
            transform.Translate(new Vector3(input.x * speed,0,input.y * speed));
            camAnimator.SetBool("isMoving" , true);
        }
        else{
            camAnimator.SetBool("isMoving",false);
        }

        //shooting mech
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("mouse clicked");
            if (Physics.Raycast(mainCam.transform.position, mainCam.transform.TransformDirection(Vector3.forward), out RaycastHit hit))
            {   
                Debug.DrawRay(mainCam.transform.position, mainCam.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit");

                Debug.Log(hit.collider.gameObject.name);
            }
            else
            {
                Debug.DrawRay(mainCam.transform.position, mainCam.transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
        }

    }


}
