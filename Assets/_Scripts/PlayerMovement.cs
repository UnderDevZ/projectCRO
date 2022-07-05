using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements; 

public class PlayerMovement : MonoBehaviour
{

    public static float Health = 100f; 
    public float moveSpeed;
    public Rigidbody2D rb;
    public KeyCode Left;
    public KeyCode Right;
    public Animator anim;
    public SpriteRenderer sprite;
    public Joystick joystick;
    public bool isGrounded;
    public Transform feetpos;
    public float checkRadius;


    public float jumpForce;
    public LayerMask whatIsGround;
    
    public Shooter shooter;
    public Bullet bullet;
    public GameObject point;

    public ParticleSystem particle;
    public static float CoinCount;
    public bool IsRush;

   
    public Canvas RushButtonCanvas;
    public GameObject RushCanvas; 
    


    



    void Start()
    {

        
        rb = GetComponent<Rigidbody2D>();

    }

    public void Jump() 
    {

        if (isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
            anim.Play("PlayerJump");
        }
       
    
    }


    void Update()
    {





        if (IsRush == true) 
        {
            Invoke("CoinDeplete", 10f);

        }
        isGrounded = Physics2D.OverlapCircle(feetpos.position, checkRadius, whatIsGround); //Remember, Physics2D.OverlapCircle

        if (isGrounded == false) 
        {
            anim.Play("PlayerJump");
        
        
        
        }



        if (Health <= 0) 
        
        {

            particle.Emit(100);
            moveSpeed = 0f;
            jumpForce = 0f;
            sprite.enabled = false;
            
            
            

        
        }




        if ((joystick.Horizontal > 0.2f) & (isGrounded == true))//Right Fast
        {

            bullet.reverse = false;
            rb.velocity = new Vector2(moveSpeed * 2, rb.velocity.y);
            anim.Play("PlayerRun");
            sprite.flipX = true;


            





        }
        else if ((joystick.Horizontal > 0.2f) & (isGrounded == false)) //Right Fast + Jump

        {

            bullet.reverse = false;
            rb.velocity = new Vector2(moveSpeed * 2, rb.velocity.y);
            anim.Play("PlayerJump");
            sprite.flipX = true;








        }



        else if ((joystick.Horizontal >= 0.1f) & (isGrounded == true))//Right normal
        {

            bullet.reverse = false;
            rb.velocity = new Vector2(moveSpeed * 2, rb.velocity.y);


            anim.Play("PlayerRun");
            sprite.flipX = true;






          



        }
        else if ((joystick.Horizontal >= 0.1f) & (isGrounded == false)) //Right normal + Jump
        {

            bullet.reverse = false;
            rb.velocity = new Vector2(moveSpeed * 2, rb.velocity.y);


            anim.Play("PlayerJump");
            sprite.flipX = true;
        }




        else if ((joystick.Horizontal <= -0.2f)& (isGrounded == true))  //Left fast
        {

            rb.velocity = new Vector2(-moveSpeed * 2, rb.velocity.y);
            anim.Play("PlayerRun");
            sprite.flipX = false;
            bullet.reverse = true;

            shootLeft();
        }
        else if ((joystick.Horizontal <= -0.2f) & (isGrounded == false)) //Left fast + Jump
        {

            rb.velocity = new Vector2(-moveSpeed * 2, rb.velocity.y);
            anim.Play("PlayerJump");
            sprite.flipX = false;
            bullet.reverse = true;

            shootLeft();
        }


        else if ((joystick.Horizontal <= -0.1f) & (isGrounded == true))//Left normal
        {

            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            anim.Play("PlayerRun");
            sprite.flipX = false;
            bullet.reverse = true;

            shootLeft();

        }
        else if ((joystick.Horizontal <= -0.1f) & (isGrounded == false)) //Left normal + Jump
        {

            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            anim.Play("PlayerJump");
            sprite.flipX = false;
            bullet.reverse = true;

            shootLeft();

        }

        else if (isGrounded == false)
        {
            anim.Play("PlayerJump");



        }

        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
            anim.Play("PlayerIdle");
        }

        if (sprite.flipX == true)
        {
            point.transform.localPosition = new Vector3(1.20f, 0f);
        }

        else if (sprite.flipX == false)
        {
            point.transform.localPosition = new Vector3(-1.20f, 0f);

        }

        if (CoinCount >=50) 
        {
            RushCanvas.SetActive(true);
            RushButtonCanvas.enabled = true;
            CoinCount = 50;


            
        }






        void shootLeft() 
        {
            shooter.ShootLeft = true;
        
        }
         
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Coin"))

        {
            CoinCount = CoinCount + 1; 
            Destroy(other.gameObject);
        }

    }

public void CyberRush()

    {

     

        moveSpeed = moveSpeed* 2;
        jumpForce = jumpForce * 5; 

        Health = Health * 2;
        
        
        
        CoinCount = CoinCount - 50;
        Invoke("StopRush", 10);



    }
    
    
    void StopRush()
    {
        moveSpeed = 5f;
        jumpForce = 10f;
        IsRush = false;

        RushCanvas.SetActive(false); 
        
       

        
        


    }
    void CoinDeplete()
    {
        CoinCount = CoinCount - 2; 
        
    
    }







}
