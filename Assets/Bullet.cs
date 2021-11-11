using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    public float speed;
    public bool reverse;
    public GameObject self;

    


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

        Invoke("SelfDestruct", 20);

    }

    public void SelfDestruct() 
    {
        self.gameObject.SetActive(false);
    
    }
    

     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            return;



        // if (collision.GetComponent<ShootingAction>())
        //     collision.GetComponent<ShootingAction>().Action();


        if (collision.tag == "Enemy" ) 
        {
            Destroy(gameObject);


        }
        
    }
}
