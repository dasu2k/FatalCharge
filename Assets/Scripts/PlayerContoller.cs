using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    // Start is called before the first frame update


    public float sens;
    public float speed ;


    
    public Camera mainCam;
    public Animator camAnimator;
    public Animator canvasAnimator;
    public Rigidbody2D rb;
    public ParticleSystem bulletImpact;



    void Start()
    {
        Cursor.lockState=CursorLockMode.Locked;
        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;
        PauseMenuControl.isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(!PauseMenuControl.isPaused)
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

                canvasAnimator.SetBool("isShooting",true);

                if (Physics.Raycast(mainCam.transform.position, mainCam.transform.TransformDirection(Vector3.forward), out RaycastHit hit))
                {
                    Debug.DrawRay(mainCam.transform.position, mainCam.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                    Debug.Log("Did Hit");

                    Destroy(Instantiate(bulletImpact,hit.point,transform.rotation),3);
                    Debug.Log(hit.collider.gameObject.name);
                    bulletImpact.Play();


                    if(hit.collider.gameObject.tag == "Enemy")
                        hit.collider.gameObject.GetComponent<EnemyController>().takeDamage();
                }


                else
                {
                    Debug.DrawRay(mainCam.transform.position, mainCam.transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                    Debug.Log("Did not Hit");
                }
            }
            else{
                canvasAnimator.SetBool("isShooting",false);
            }
        }
    }
}
