using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    public float speed;
    public bool reverse;
    public GameObject self;
    public ParticleSystem explosion; 
    


    public void Update()
    {
        

        if (reverse == true)
        {
            transform.Translate(transform.right * transform.localScale.x * -speed * Time.deltaTime);
        }
        if (reverse == false) 
        {
            transform.Translate(transform.right * transform.localScale.x * speed * Time.deltaTime);

        }

        Invoke("SelfDestruct", 10);
        explosion.Emit(100);

    }

    public void SelfDestruct() 
    {
        self.gameObject.SetActive(false);
    
    }

    
    

      void OnCollisionEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SelfDestruct();
            Debug.Log("Bullet is Touching Player"); 
            
            
        }













       else if (collision.CompareTag("Enemy"))
        {
            SelfDestruct();
            explosion.Emit(100);
            Debug.Log("Bullet is touching Enemy"); 
           


        }

        
        
    }


   
}
