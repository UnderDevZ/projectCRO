using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class BlobEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject self;
    public int Health = 3;
    public Slider healthbar;


    private bool isTouchingWall;
    private bool isNearFloor;
    private bool isGrounded;
    private bool canMove;
    private bool isInRange;
    private bool canTurn;
    private bool canDamage;

    private int facingDirection = -1;

    public float wallCheckDistance;
    public float floorCheckDistance;

    public float moveSpeed;
    public float patrolSpeed;
    public float jumpForce;
    public float attackRadius;
    public float stopRadius;
    public float timeBetweenJumps;
    public float minPatrolHeight;
    public float maxPatrolHeight;

    public bool isEnemy1;
    public bool isEnemy2;
    public bool isEnemy3;

    public Transform wallCheck;
    public Transform floorCheck;
    private Transform player;

    public GameObject Flag;

    public LayerMask wallLayerMask;
    public LayerMask floorLayerMask;


    public Animator OrbAnim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        self = gameObject;
        OrbAnim.Play("OrbIdle");
    }


    public void TakeDamage(int damage)
    {

        Health -= damage;

        if (Health <= 0)
        {

            OrbAnim.Play("OrbDie");
            Die();

            Flag.SetActive(true);

        }

    }


    void Die()


    {

        OrbAnim.Play("OrbDie");
        Invoke("Death",1);

    }
    private void Update()
    {
        if (Health <= 0) 
        {
            
            Die();
        }

        CheckMovementDirection();

        healthbar.value = Health;
    }

    private void FixedUpdate()
    {
        if (isEnemy1)
        {
            rb.velocity = new Vector2(moveSpeed * facingDirection, rb.velocity.y);
        }

        else if (isEnemy2 && canMove)
        {
            rb.velocity = new Vector2(moveSpeed * facingDirection, rb.velocity.y);
            if (isGrounded)
            {
                Jump();
            }
        }

        if (isEnemy3)
        {
            rb.gravityScale = 0;

            if (isInRange)
            {
                rb.velocity = new Vector2(0, 0);

                if (Vector2.Distance(transform.position, player.position) > stopRadius)
                {
                    transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
                }

                else
                {
                    rb.constraints = RigidbodyConstraints2D.FreezePositionY; 
                }
            }

            else
            {
                rb.velocity = new Vector2(moveSpeed * facingDirection, 0);
                if (transform.position.y < minPatrolHeight)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y + Time.deltaTime * 2);
                }
                else if (transform.position.y > maxPatrolHeight)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y - Time.deltaTime * 2);
                }
            }
        }

        isTouchingWall = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, wallLayerMask);
        isNearFloor = Physics2D.Raycast(floorCheck.position, -transform.up, floorCheckDistance, floorLayerMask);
    }

    void CheckMovementDirection()
    {
        if (isEnemy2)
        {
            if (isTouchingWall || (!isNearFloor && isGrounded))
            {
                TurnAround();
            }
        }

        else if (isEnemy1 && (isTouchingWall || !isNearFloor))
        {
            TurnAround();
        }

        else if (isEnemy3)
        {

            if (canTurn && (isTouchingWall || !isNearFloor))
            {
                TurnAround();
            }

            if (Vector2.Distance(transform.position, player.position) <= attackRadius)
            {
                isInRange = true;
                canTurn = false;
            }
            else
            {
                isInRange = false;
                canTurn = true;
            }
        }
    }

    void TurnAround()
    {
        facingDirection *= -1;
        transform.Rotate(0, 180, 0);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    IEnumerator CanMove()
    {
        canMove = false;
        yield return new WaitForSeconds(timeBetweenJumps);
        canMove = true;
    }

    IEnumerator CanDamage()
    {
        canDamage = false;
        // disable collision with all enemy types
        yield return new WaitForSeconds(1);
        // enable collision with all enemy types
        canDamage = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerMovement.Health = (PlayerMovement.Health - 10);
            

            Debug.Log("Damaged");
            // enemy damage script will go here
            if (canDamage)
            {
                StartCoroutine(CanDamage());
                // player can't be damaged for a couple of seconds
            }
        }

        if (other.gameObject.tag == "Ground")
        {
            StartCoroutine(CanMove());
            isGrounded = true;
        }

        if (other.gameObject.tag == "Bullet") 
        {
            Health = Health - 1;
        
        }



    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }

        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y, wallCheck.position.z));
        Gizmos.DrawLine(floorCheck.position, new Vector3(floorCheck.position.x, floorCheck.position.y - floorCheckDistance, floorCheck.position.z));
    }

    void Death() 
    {

        Destroy(gameObject);


    }


}

// attack cooldown time for enemy 3 (where they move away from the player)