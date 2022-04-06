using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    //player attributes
    public int speed;
    public float jumpForce;
    public bool isGrounded = true;

    //components
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public Rigidbody2D character;

    void Update()
    {
        Movement();

        if (isGrounded)
        {
            animator.SetBool("isGrounded", true);
        }
        else
        {
            animator.SetBool("isGrounded", false);
        }

        if (character.velocity.y < 0)
        {
            character.velocity += Vector2.up * Physics2D.gravity.y * Time.deltaTime;
        }

    }

    void Movement()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                isGrounded = false;
                character.AddForce(Vector2.up * jumpForce);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isWalking", true);
            transform.Translate(new Vector2(speed * Time.deltaTime, 0));
            spriteRenderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isWalking", true);
            transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
            spriteRenderer.flipX = false;
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            animator.SetBool("isGrounded", true);
        }
    }
}
