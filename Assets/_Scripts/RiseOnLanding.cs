using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiseOnLanding : MonoBehaviour
{
    public Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D Player)
    {
        if (Player.CompareTag("Player"))

        {


            rb.gravityScale = -1f;
            Debug.Log("Player Touched The Platform");


        }

    }






}
