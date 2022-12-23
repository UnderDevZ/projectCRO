using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InsanityBox : MonoBehaviour
{
    public GameObject self; 
    public PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))

        {
            PlayerMovement.Health = (PlayerMovement.Health - 10);
            playerMovement.moveSpeed = playerMovement.moveSpeed / 2;
            playerMovement.rb.constraints = RigidbodyConstraints2D.None;
            self.SetActive(false);
            

        }
   
        }

    }
