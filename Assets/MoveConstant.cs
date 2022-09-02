using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveConstant : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed; 
    void Start()
    {
        rb = rb.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(moveSpeed, 0f);
    }
}
