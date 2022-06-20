using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MiniController : MonoBehaviour
{

    public static float Health = 100f;
    public float moveSpeed;
    public Rigidbody2D rb;
   
    public Animator anim;
    public SpriteRenderer sprite;
    public Joystick joystick;
    public bool isGrounded;
    public Transform feetpos;
    public float checkRadius;


    public float jumpForce;
    public LayerMask whatIsGround;

    public Shooter shooter;
    
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
            
        }


    }


    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetpos.position, checkRadius, whatIsGround); //Remember, Physics2D.OverlapCircle

        if (isGrounded == false)
        {

           


        }



      




        if (joystick.Horizontal > 0.2f) //Right Fast
        {

           
            rb.velocity = new Vector2(moveSpeed * 2, rb.velocity.y);
            anim.Play("MiniMove");
            sprite.flipX = false;


            //  shooter.shootingPoint.transform.position = new Vector3(-shooter.shootingPoint.localPosition.x, 0f,0f);





        }




        else if (joystick.Horizontal >= 0.1f) //Right Normal
        {

            
            rb.velocity = new Vector2(moveSpeed * 2, rb.velocity.y);


            anim.Play("MiniMove");
            sprite.flipX = false;





            //  shooter.shootingPoint.transform.position = new Vector3(-shooter.shootingPoint.localPosition.x, 0f,0f);



        }





        else if (joystick.Horizontal <= -0.2f) //Left Fast
        {

            rb.velocity = new Vector2(-moveSpeed * 2, rb.velocity.y);
            anim.Play("MiniMove");
            sprite.flipX = true;
        
            shootLeft();
        }


        else if (joystick.Horizontal <= -0.1f) //Left Normal
        {

            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            anim.Play("MiniMove");
            sprite.flipX = true;
            
            shootLeft();

        }

        else if (isGrounded == false)
        {
           



        }

        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
            
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
