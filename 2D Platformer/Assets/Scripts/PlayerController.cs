using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jump;
    float moveVelocity;
    bool isGrounded = false;
    public LayerMask playerMask;

    Transform tagGround;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        tagGround = GameObject.Find(this.name + "/tag_ground").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.Linecast(transform.position, tagGround.position, playerMask);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jump);
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
}