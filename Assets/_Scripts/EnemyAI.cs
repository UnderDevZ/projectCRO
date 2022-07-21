using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{


    public Transform player;
    public float agroRange;
    public float moveSpeed;

    public Rigidbody2D rb;
    public Animator EnemyAnim;

    EnemyScript enemyScript;
    public GameObject Enemy;
    void Start()
    {
        enemyScript = Enemy.GetComponent<EnemyScript>();
        rb = GetComponent<Rigidbody2D>();
        EnemyAnim.Play("FoxIdle");
      
    }

    void ChasePlayer() 
    {
        if (transform.position.x < player.position.x)
        {
            rb.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(1, 1);
           
        }
        else if (transform.position.x < player.position.x)
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-1, 1);
            
        }
    }

    void Stop() 
    {
        rb.velocity = Vector2.zero;
       
        EnemyAnim.Play("FoxIdle");
    }


    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);
  

        if ((distance < agroRange) & (enemyScript.EnemyHealth > 0))
        {
            ChasePlayer();
            EnemyAnim.Play("FoxRun");
            
        }

        else 
        {
            
        
        }
    }
}
