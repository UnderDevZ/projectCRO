using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    
    public Animator anim; 
    public bool IsDriving; 
    
    



    
    void Start()
    {
        rb = rb.GetComponent<Rigidbody2D>(); 
    }

   
    void Update()
    {
        if (IsDriving == true)
        {

            anim.Play("Car");

        }

        else 
        {
            anim.Play("CarIdle");
        
        }
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))

        {
            IsDriving = true;
            Drive();
            Debug.Log("Driving With Player");

        }


        else
            {

            IsDriving = false;
            rb.velocity = new Vector2(0f, 0f);
        
        
        
        }
               
        
        

        void Drive() 
    {
        rb.velocity = new Vector2(moveSpeed, 0f); 
        
    
    }


    
        }
        
    }


    


