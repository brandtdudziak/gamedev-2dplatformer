using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jump;
    public float jumpPush;
    public float wallJumpDelay;
    float timerWJ;
    float moveVelocity;
    public LayerMask playerMask;
    bool isGrounded = false;
    bool isOnWallLeft = false;
    bool isOnWallRight = false;
    bool wallJump = false;
    bool hasWallJumpedL = false;
    bool hasWallJumpedR = false;

    Transform tagGround;
    Transform tagWallRight;
    Transform tagWallLeft;
    Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        tagGround = GameObject.Find(this.name + "/tag_ground").transform;
        tagWallRight = GameObject.Find(this.name + "/tag_wallright").transform;
        tagWallLeft = GameObject.Find(this.name + "/tag_wallleft").transform;
        timerWJ = wallJumpDelay;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Jump();
        if (!wallJump)
        {
            Move();
        }
        else
        {
            if(timerWJ < 0)
            {
                wallJump = false;
                timerWJ = wallJumpDelay;
            }
            else
            {
                timerWJ -= Time.deltaTime;
            }
        }

        if(isGrounded)
        {
            hasWallJumpedL = false;
            hasWallJumpedR = false;
        }
    }

    public void Move()
    {
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

    public void Jump()
    {
        isGrounded = Physics2D.Linecast(transform.position, tagGround.position, playerMask);
        isOnWallLeft = Physics2D.Linecast(transform.position, tagWallLeft.position, playerMask);
        isOnWallRight = Physics2D.Linecast(transform.position, tagWallRight.position, playerMask);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jump);
            }

            if (isOnWallLeft && !isGrounded && !hasWallJumpedL)
            {
                rb2d.velocity = new Vector2(jumpPush, jump);
                wallJump = true;
                hasWallJumpedR = false;
                hasWallJumpedL = true;
            }

            if (isOnWallRight && !isGrounded && !hasWallJumpedR)
            {
                rb2d.velocity = new Vector2(-jumpPush, jump);
                wallJump = true;
                hasWallJumpedL = false;
                hasWallJumpedR = true;
            }
        }
    }
}