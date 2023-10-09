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
    public static float health;

    public bool hasKey;

    public bool isShooting;

    public AudioSource walking;
    public AudioSource gunshot;
    
    public static Transform player ;
    public Camera mainCam;
    public Animator camAnimator;
    public Animator canvasAnimator;
    
    private Rigidbody2D rb;
    void Awake(){
    }
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

    public void takeDamage(float damage){
        health-=damage;
        canvasAnimator.SetBool("isHit",true);
        if(health <= 0 )
        {
            Debug.Log("you died");
        }
    }

    public void heal(float healing)
    {
        if(health < 10)
        {
            if(health+healing > 10)
                health =10f;
            else
                health += healing;
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
                canvasAnimator.SetBool("isMoving" , true);
            }
            else{
                camAnimator.SetBool("isMoving",false);
                canvasAnimator.SetBool("isMoving" , false);
            }

            //shooting mech
            shoot();
        }
    }

    void shootingComplete()
    {
        canvasAnimator.SetBool("isShooting",false);
        isShooting=false;
        
    }

    void shoot()
    {
        if(Input.GetMouseButtonDown(0) && isShooting==false)
        {
            //turn on shooting animation
            canvasAnimator.SetBool("isShooting",true);
            isShooting=true;
            Debug.Log("shot!");
            Invoke("shootingComplete",0.23f);
            //raycasting to find target and give damage if its an enemy 
            if (Physics.Raycast(mainCam.transform.position, mainCam.transform.TransformDirection(Vector3.forward), out RaycastHit hit))
            {
                Debug.DrawRay(mainCam.transform.position, mainCam.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);    
                Instantiate(bulletImpact, hit.point, Quaternion.identity);
                //if target is enemy call its takeDamage() func
                if(hit.collider.gameObject.tag == "Enemy"){
                    hit.collider.gameObject.GetComponentInParent<NecroControl>().takeDamage();
                }
                else if(hit.collider.gameObject.tag == "GreenMonk")
                {
                    hit.collider.gameObject.GetComponentInParent<GreenMonkControl>().takeDamage();
                }   
            }
        }
    }
}
    