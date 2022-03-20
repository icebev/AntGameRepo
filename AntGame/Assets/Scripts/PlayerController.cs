using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce;

    public Color color;

    private Material outlineMaterial;
    private Material regularMaterial;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.gameObject.GetComponent<Rigidbody2D>();
        this.outlineMaterial = this.gameObject.GetComponent<SpriteRenderer>().material;
        this.regularMaterial = new Material(Shader.Find("Universal Render Pipeline/2D/Sprite-Lit-Default"));

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
        
        if (Input.GetKeyDown(KeyCode.O))
        {
            // assign the material to the renderer
            this.gameObject.GetComponent<SpriteRenderer>().material = this.regularMaterial;
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            this.gameObject.GetComponent<SpriteRenderer>().material = this.outlineMaterial;

        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            this.gameObject.GetComponent<SpriteRenderer>().material.color = this.color;
        }
        

        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);//getting cursor position

        if (Mathf.Abs(cursorPosition.x - this.gameObject.transform.position.x) < 2 && Mathf.Abs(cursorPosition.y - this.gameObject.transform.position.y) < 2)
        {
            this.gameObject.GetComponent<SpriteRenderer>().material = this.outlineMaterial;

        } 
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().material = this.regularMaterial;

        }

    }
}
