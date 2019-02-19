using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 input;

    float speed = 5;
    Rigidbody2D rb2d = null;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 velocity = rb2d.velocity;

        velocity.x = input.x * speed;

        rb2d.velocity = velocity;
    }
}
