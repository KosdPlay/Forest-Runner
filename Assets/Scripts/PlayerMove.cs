using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horisontalMove = 0f;
    private bool facingRight = true;

    [Header("Player Movement Settings")]
    [Range (0, 10f)] [SerializeField] private float speed = 1f;
    [Range(0, 15f)] [SerializeField] private float jumpForce = 4f;

    [Header("Player Animation Settings")]
    [SerializeField] Animator animator;

    [Space]
    [Header("Ground Checker Settings")]
    [SerializeField] private bool isGrounded = true;
    [Range(-5, 5f)] [SerializeField] private float checkGroundOffsetY = -1.1f;
    [Range(0, 15f)] [SerializeField] private float checkGroundRadius = 0.5f;

    public AudioClip music;
    AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        audio.PlayOneShot(music);
    }


    private void Update()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }

        horisontalMove = Input.GetAxisRaw("Horizontal") * speed;

        animator.SetFloat("HorizontalMove", Mathf.Abs(horisontalMove));

        if(isGrounded == false)
        {
            animator.SetBool("Jumping", true);
        }
        else
        {
            animator.SetBool("Jumping", false);
        }

        if (facingRight && horisontalMove < 0)
        {
            Flip();
        }
        else if (!facingRight && horisontalMove > 0)
        {
            Flip();
        }
    }


    private void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(horisontalMove * 10f, rb.velocity.y);
        rb.velocity = targetVelocity;

        GroundChecker();
    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }

    private void GroundChecker()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y + checkGroundOffsetY), checkGroundRadius);

        if (colliders.Length > 2)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
