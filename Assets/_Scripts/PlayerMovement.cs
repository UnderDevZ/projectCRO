using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

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
    private float CoyoteTime = 0.2f;
    private float CoyoteTimeCounter;

    public LayerMask whatIsGround;

    public Shooter shooter;
    public Bullet bullet;
    public GameObject point;

    public ParticleSystem particle;
    public static float CoinCount;
    public bool isRush;


    public Canvas RushButtonCanvas;
    public GameObject RushCanvas;







    void Start()
    {


        rb = GetComponent<Rigidbody2D>();
        sprite.flipX = true;
        bullet.reverse = false;


    }

    public void Jump()
    {

        if (CoyoteTimeCounter > 0f)
        {

            rb.velocity = Vector2.up * jumpForce;
            anim.Play("PlayerJump");
            CoyoteTimeCounter = 0f;

        }



    }




    void Update()
    {



        if (CoinCount > 100)
        {
            CoinCount = 100;

        }

        if (CoinCount < 0)
        {
            CoinCount = 0;
        }


        if (isRush == true)
        {
            moveSpeed = 20f;
            jumpForce = 100f;

        }


        if (isGrounded == true)
        {
            CoyoteTimeCounter = CoyoteTime;

        }

        else
        {
            CoyoteTimeCounter = CoyoteTimeCounter - Time.deltaTime;

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
            Invoke("DeathScreen", 2);




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




        else if ((joystick.Horizontal <= -0.2f) & (isGrounded == true))  //Left fast
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

        if (sprite.flipX == true & bullet.reverse == false)
        {
            point.transform.localPosition = new Vector3(1.20f, 0f);
        }

        else if (sprite.flipX == false & bullet.reverse == true)
        {
            point.transform.localPosition = new Vector3(-1.20f, 0f);

        }

        if (CoinCount >= 50)
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

        if (other.gameObject.CompareTag("Spike"))
        {

            Health = 0f; 
        
        }

    }

    public void CyberRush()

    {
        isRush = true;
        Health = Health + 15;



        CoinCount = CoinCount - 50;
        Invoke("StopRush", 10f);


        RushCanvas.SetActive(false);
        RushButtonCanvas.enabled = false;



    }


    void StopRush()
    {
        isRush = false;
        moveSpeed = 5f;
        jumpForce = 10f;



        RushCanvas.SetActive(false);
        RushButtonCanvas.enabled = false;







    }
    void CoinDeplete()
    {
        CoinCount = CoinCount - 2;


    }

    void DeathScreen()
    {
        SceneManager.LoadScene("GameOver");
        Invoke("SpriteEnabled", 3.1f);
        moveSpeed = 5f;
        jumpForce = 11f;
        particle.Stop();
        Health = 100f;




    }

    private void SpriteEnabled()
    {
        sprite.enabled = true;

    }


   








    }
