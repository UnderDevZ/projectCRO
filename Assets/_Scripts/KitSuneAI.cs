using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitSuneAI : MonoBehaviour
{


    public float range;
    public Transform Player;
    public Animator KitsuneAnim; 


    private float distToPlayer; 


    void Start()
    {
        
    }

    void Update()
    {
        if (Player.position.x > transform.position.x && transform.localPosition.x < 0 ||
            Player.position.x < transform.position.x && transform.localPosition.x > 0)
        {

            Flip();
        }

        





        distToPlayer = Vector2.Distance(transform.position, Player.position); //calculates the distance between the 2 objects. 
        if (distToPlayer <= range) 
        {

            Kunai();
            Debug.Log("Player Detected");
        }

        

        else if (distToPlayer >= range)
        {
            KitsuneAnim.Play("KitsuneIdle");
            


        }
    }



    void Kunai() 
    
    {

        KitsuneAnim.Play("KitsuneThrow"); 
    }

    void Flip() 
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    
    }
}
