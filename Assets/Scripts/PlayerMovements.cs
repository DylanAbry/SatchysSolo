using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float speed;
    public float jumpForce = 10f;
    public float normalGravity = 6f;
    public float paraGravity = 0.5f;

    private Rigidbody2D rb;
    private Vector2 movement;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {       
        movement.x = Input.GetAxisRaw("Horizontal");

        if ((Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A) && Input.GetKey(KeyCode.D)) && Input.GetKey(KeyCode.S))
        {
            Attack();
        }
        else if ((Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A) && Input.GetKey(KeyCode.D)) && isGrounded)
        {
            Jump();
        }
        else if (Input.GetKey(KeyCode.S) && rb.velocity.y < 0)
        {
            Parachute();
        }
        else
        {
            rb.gravityScale = normalGravity;
        }


    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
    }

    void Parachute()
    {
        rb.gravityScale = paraGravity;
    }

    void Attack()
    {
        Debug.Log("Attacked!");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
