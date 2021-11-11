using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
        isGrounded = Physics2D.OverlapCircle(feetpos.position, checkRadius, whatIsGround); //Remember, Physics2D.OverlapCircle

        if (isGrounded == false) 
        {
            anim.Play("PlayerJump");
        
        
        
        }

        
      





        if (joystick.Horizontal > 0.2f ) //Right Fast
        {

            bullet.reverse = false;
            rb.velocity = new Vector2(moveSpeed * 2, rb.velocity.y);
            anim.Play("PlayerRun");
            sprite.flipX = true;


          //  shooter.shootingPoint.transform.position = new Vector3(-shooter.shootingPoint.localPosition.x, 0f,0f);
            

           
         

        }

      


        else if (joystick.Horizontal >= 0.1f) //Right Normal
        {

            bullet.reverse = false;
            rb.velocity = new Vector2(moveSpeed * 2, rb.velocity.y);


            anim.Play("PlayerRun");
            sprite.flipX = true;





            //  shooter.shootingPoint.transform.position = new Vector3(-shooter.shootingPoint.localPosition.x, 0f,0f);



        }





        else if (joystick.Horizontal <= -0.2f) //Left Fast
        {

            rb.velocity = new Vector2(-moveSpeed * 2, rb.velocity.y);
            anim.Play("PlayerRun");
            sprite.flipX = false;
            bullet.reverse = true;

            shootLeft();
        }


        else if (joystick.Horizontal <= -0.1f) //Left Normal
        {

            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            anim.Play("PlayerRun");
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



        void shootLeft() 
        {
            shooter.ShootLeft = true;
        
        }
        
    }

   

  

    



}
