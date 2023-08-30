using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    // Start is called before the first frame update
    public float sens =3f;
    public Transform camTransform;
    private bool isGrounded;
    public Rigidbody rb;
    public float speed = 10f;
    void Start()
    {
        sens = 3f;
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        //mouse input stuff
        
        camTransform.Rotate(-sens*(Input.GetAxis("Mouse Y")) , 0 , 0 , Space.Self);
        transform.Rotate(0,sens*(Input.GetAxis("Mouse X")),0,Space.Self);
        
        //player movement
         
        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * 0.03f,0,Input.GetAxis("Vertical") * 0.03f));

        if(Input.GetButton("Jump") && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(transform.up * 10f);
        }
        Debug.Log(isGrounded);

    }
    
void OnCollisionEnter(Collision collision){
    Debug.Log("collision!");
    if(collision.other.tag == "Ground")
        isGrounded = true;
}

}
