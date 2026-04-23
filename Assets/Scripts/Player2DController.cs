using UnityEngine;
using UnityEngine.InputSystem;

public class Player2DController : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumForce = 450f;

    private Rigidbody2D rb;
    private float moveInput;
    private bool isGrounded = false;
    private SpriteRenderer mr;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        mr = GetComponent<SpriteRenderer>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current != null)
        {
            moveInput = (Keyboard.current.dKey.isPressed ? 1 : 0) - (Keyboard.current.aKey.isPressed ? 1 : 0);
        }
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        if (moveInput < 0)
        {
            mr.flipX = true;
        }
        else if (moveInput > 0)
        {
            mr.flipX = false;
        }

        if(Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            rb.AddForce(new Vector2(rb.linearVelocity.x, jumForce));
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
