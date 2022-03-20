using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            this.rb.AddForce(Vector2.up * this.jumpForce);
        }

        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) != 0)
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                this.rb.AddForce(Vector2.right * this.jumpForce * 1.2f * Time.deltaTime);
            }
            else
            {
                this.rb.AddForce(Vector2.left * this.jumpForce * 1.2f * Time.deltaTime);
            }

        }
    }
}
