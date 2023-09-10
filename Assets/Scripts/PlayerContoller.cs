using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletImpact;
    public static PlayerContoller playerContoller ;
    public float sens;
    public float speed;
    public static int health;



    public AudioSource walking;
    
    

    public AudioSource gunshot;


    public static Transform player ;
    public Camera mainCam;
    public Animator camAnimator;
    public Animator canvasAnimator;
    
    private Rigidbody2D rb;

    void Start()
    {
        playerContoller = this;
        Cursor.lockState=CursorLockMode.Locked;
        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 1f;
        PauseMenuControl.isPaused = false;
        player = transform;
        health = 10;
    }

    public void takeDamage(int damage){
        health-=damage;
        Debug.Log("you took damage");
        canvasAnimator.SetBool("isHit",true);
        if(health <= 0 )
        {
            Debug.Log("you died");
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(!PauseMenuControl.isPaused)
        {
            Vector2 input = new Vector2(Input.GetAxis("Horizontal") , Input.GetAxis("Vertical"));
            //mouse input and camera rotation
            mainCam.transform.Rotate(-sens*(Input.GetAxis("Mouse Y")) , 0 , 0 , Space.Self);
            transform.Rotate(0,sens*(Input.GetAxis("Mouse X")),0,Space.Self);
            
            //player movement
            if(input != Vector2.zero)
            {
                transform.Translate(new Vector3(input.x ,0,input.y) * Time.deltaTime * speed);
                camAnimator.SetBool("isMoving" , true);
                if(mainCam.transform.position.z > 1.1f)
                    walking.Play();
                
            }
            else{
                camAnimator.SetBool("isMoving",false);
            }

            //shooting mech
            shoot();
        }
    }


    void shoot()
    {
        if(Input.GetMouseButtonDown(0))
            {
                gunshot.Play();
                //turn on shooting animation
                canvasAnimator.SetBool("isShooting",true);

                //raycasting to find target and give damage if its an enemy 
                if (Physics.Raycast(mainCam.transform.position, mainCam.transform.TransformDirection(Vector3.forward), out RaycastHit hit))
                {
                    Debug.DrawRay(mainCam.transform.position, mainCam.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                    Debug.Log("Did Hit");
                    Instantiate(bulletImpact, hit.point, Quaternion.identity);
                    //if target is enemy call its takeDamage() func
                    if(hit.collider.gameObject.tag == "Enemy")
                        hit.collider.gameObject.GetComponent<EnemyController>().takeDamage();
                }
            }
            //if not shooting set the shooting parameter to false
            else{
                canvasAnimator.SetBool("isShooting",false);
            }
    }
}
