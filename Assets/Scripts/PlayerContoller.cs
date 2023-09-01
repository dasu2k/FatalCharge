using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    // Start is called before the first frame update
    public float sens =3f;
    public Camera mainCam;

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
        //mouse input stuff
        
        mainCam.transform.Rotate(-sens*(Input.GetAxis("Mouse Y")) , 0 , 0 , Space.Self);
        transform.Rotate(0,sens*(Input.GetAxis("Mouse X")),0,Space.Self);
        
        //player movement
         
        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * speed,0,Input.GetAxis("Vertical") * speed));

    }


}
