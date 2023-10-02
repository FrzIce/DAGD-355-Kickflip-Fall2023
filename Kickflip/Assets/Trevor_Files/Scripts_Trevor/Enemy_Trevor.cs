using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Player player;

    public int health;
    public float jumpForce = 5;
    public float speed = 3;
    public float horizontalMovement;
    public float verticalMovement;
    public bool grounded;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        health = 2;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        print(health);
        if (player.transform.position.x < transform.position.x)
        {
            horizontalMovement = speed * -1;
        }
        else if (player.transform.position.x > transform.position.x) 
        {
            horizontalMovement = speed;
        }
        rb.velocity = new Vector2(horizontalMovement, rb.velocity.y);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Recall Collision")
        {
            health -= 2;
        }
        else if(collision.gameObject.tag == "Jump Platform")
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            grounded = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            
        }
    }




}
