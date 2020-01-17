using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // movement
    public float speed = 5f;
    public float jumpSpeed = 5f;
    private float movement = 0f;
    private Rigidbody2D rigidBody;

    // ground check
    public LayerMask groundLayer;
    private bool isOnGround;

    // flipping
    public float horizontal;
    private bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D> ();
        isFacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        isOnGround = Physics2D.OverlapArea (new Vector2 (transform.position.x - 0.25f, transform.position.y - 1f),
        new Vector2 (transform.position.x + 0.25f, transform.position.y - 1.01f), groundLayer);
        movement = Input.GetAxis ("Horizontal");
        if(movement > 0f)
        {
            rigidBody.velocity = new Vector2(movement*speed, rigidBody.velocity.y);
        }
        else if(movement < 0f)
        {
            rigidBody.velocity = new Vector2(movement*speed, rigidBody.velocity.y);
        }
        else
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }

        if(Input.GetButtonDown ("Jump") && isOnGround)   
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
        }

        Flip(movement);
    }

    private void Flip(float horizontal)
    {
        if(horizontal > 0 && !isFacingRight || horizontal < 0 && isFacingRight)
        {
            isFacingRight = !isFacingRight;

            Vector2 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
