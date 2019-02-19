using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jump;
    float moveVelocity;
    Rigidbody2D rb2d = null;
    bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jump);
                isGrounded = false;
            }
        }

        moveVelocity = 0;

        if (Input.GetKey(KeyCode.A))
        {
            moveVelocity = -speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveVelocity = speed;
        }

        rb2d.velocity = new Vector2(moveVelocity, rb2d.velocity.y);
    }

    void OnCollisionEnter2D()
    {
        isGrounded = true;
    }
}