using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHover : MonoBehaviour
    
{



    public int HoverSpeed;
    public Rigidbody2D rb; 
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("moveUp", 1);

    }


    void Update()
    {
        
    }


    void moveUp() 
    
    {
        rb.velocity = new Vector2(0f, HoverSpeed);
        Invoke("moveDown", 1);
        
    
    }

    void moveDown() 
    {
        rb.velocity = new Vector2(0f, -HoverSpeed);
        Invoke("moveUp", 1);
    
    }
}
