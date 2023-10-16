using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Player player;
    public Animator animator;
    public GameObject deathParticle;

    public AudioSource death;

    public int health;
    public float jumpForce = 5;
    public float speed = 3;
    public float horizontalMovement;
    public float verticalMovement;
    public bool grounded;
    bool facingRight = true;
    bool jumpPlatform1 = false;
    bool jumpPlatform2 = false;
    bool jumpPlatform3 = false;
    bool facingPlayer = false;
    bool flip = false;

    bool underPlatform = false;
    string platform = "Null";

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        animator = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>();

        health = 2;
        rb = GetComponent<Rigidbody2D>();
        death = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            death.Play();
            var instance = Instantiate(deathParticle, transform.position, transform.rotation);
            //Destroy(instance.gameObject, 1.0f);
            Destroy(gameObject);
        }

        print("flip is " + flip);
        //print(jumpPlatform1);
        if (player.transform.position.x > transform.position.x && (facingRight))
        {
            facingPlayer = true;
        }
        else if(player.transform.position.x < transform.position.x && (!facingRight))
        {
            facingPlayer = true;
        }
        else
        {
            facingPlayer = false;
        }
        //print(health);

        if (player.platform == "Null")
        {
            if (player.transform.position.x < transform.position.x)
            {
                horizontalMovement = speed * -1;
            }
            else if (player.transform.position.x > transform.position.x)
            {
                horizontalMovement = speed;
            }
        }
        else if (player.platform == "A")
        {
            if(transform.position.x < -7 && transform.position.x > -17 && transform.position.y <= -2)
            {
                underPlatform = true;
            }
            if (underPlatform == true)
            {
                if (transform.position.x <= -12)
                {
                    horizontalMovement = speed * -1;
                }
                else if (transform.position.x > -12)
                {
                    horizontalMovement = speed;
                }
            }
            else if (transform.position.x <= -12)
            {
                horizontalMovement = speed;
            }
            else if (transform.position.x > -12)
            {
                horizontalMovement = speed * -1;
            }          
            
            
            if (jumpPlatform1 == true)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                grounded = false;
                underPlatform = false;
                if (facingPlayer == false)
                {
                    Flip();
                }
            }

        }
        else if (player.platform == "B")
        {
            if (transform.position.x < 27 && transform.position.x > 17 && transform.position.y <= -2)
            {
                underPlatform = true;
            }
            if (underPlatform == true)
            {
                if (transform.position.x <= 22)
                {
                    horizontalMovement = speed * -1;
                }
                else if (transform.position.x > 22)
                {
                    horizontalMovement = speed;
                }
            }
            else if (transform.position.x <= 22)
            {
                horizontalMovement = speed;
            }
            else if (transform.position.x > 22)
            {
                horizontalMovement = speed * -1;
            }

            if (jumpPlatform1 == true)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                grounded = false;
                underPlatform = false;
                if (facingPlayer == false)
                {
                    Flip();
                }
            }
        }
        else if (player.platform == "C")
        {
            if (transform.position.y < 0)
            {
                if (transform.position.x < -7 && transform.position.x > -17 && transform.position.y <= -2)
                {
                    underPlatform = true;
                }
                if (underPlatform == true)
                {
                    if (transform.position.x <= -12)
                    {
                        horizontalMovement = speed * -1;
                    }
                    else if (transform.position.x > -12)
                    {
                        horizontalMovement = speed;
                    }
                }
                else if (transform.position.x <= -12)
                {
                    horizontalMovement = speed;
                }
                else if (transform.position.x > -12)
                {
                    horizontalMovement = speed * -1;
                }


                if (jumpPlatform1 == true)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    grounded = false;
                    underPlatform = false;
                    if (facingPlayer == false)
                    {
                        Flip();
                    }
                }
            }
            if (transform.position.x >= -17 && transform.position.x <= -7)
            {
                if (flip == false)
                {
                    if (transform.position.x < -13)
                    {
                        horizontalMovement = speed;
                    }
                    else if (transform.position.x > -11)
                    {
                        horizontalMovement = speed * -1;
                    }
                    else if (transform.position.x >= -13 && transform.position.x <= -11)
                    {
                        flip = true;
                    }
                }
                else if (flip == true)
                {
                    horizontalMovement = speed * -1;
                    if (jumpPlatform2 == true)
                    {
                        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                        grounded = false;
                        if (facingPlayer == false)
                        {
                            Flip();
                        }
                    }
                }
                
            }
        }
        else if (player.platform == "D")
        {
            if (transform.position.x <= 6)
            {
                if (transform.position.y < -.5)
                {

                    if (transform.position.x < -7 && transform.position.x > -17 && transform.position.y <= -2)
                    {
                        underPlatform = true;
                    }
                    if (underPlatform == true)
                    {
                        if (transform.position.x <= -12)
                        {
                            horizontalMovement = speed * -1;
                        }
                        else if (transform.position.x > -12)
                        {
                            horizontalMovement = speed;
                        }
                    }
                    else if (transform.position.x <= -12)
                    {
                        horizontalMovement = speed;
                    }
                    else if (transform.position.x > -12)
                    {
                        horizontalMovement = speed * -1;
                    }


                    if (jumpPlatform1 == true)
                    {
                        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                        grounded = false;
                        underPlatform = false;
                        if (facingPlayer == false)
                        {
                            Flip();
                        }
                    }
                }
                else if (transform.position.x >= -17 && transform.position.x <= -7)
                {
                    if (flip == false)
                    {
                        if (transform.position.x < -13)
                        {
                            horizontalMovement = speed;
                        }
                        else if (transform.position.x > -11)
                        {
                            horizontalMovement = speed * -1;
                        }
                        else if (transform.position.x >= -13 && transform.position.x <= -11)
                        {
                            flip = true;
                        }
                    }
                    else if (flip == true)
                    {
                        print("test");
                        horizontalMovement = speed;
                        if (jumpPlatform2 == true)
                        {
                            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                            grounded = false;
                            if (facingPlayer == false)
                            {
                                Flip();
                            }
                        }
                        else
                        {

                        }
                    }

                }
            }
            else if (transform.position.x > 6) //enemy moves right not left
            {
                if (transform.position.y < -.5)
                {

                    if (transform.position.x < 27 && transform.position.x > 17 && transform.position.y <= -2)
                    {
                        underPlatform = true;
                    }
                    if (underPlatform == true)
                    {
                        if (transform.position.x <= 22)
                        {
                            horizontalMovement = speed * -1;
                        }
                        else if (transform.position.x > 22)
                        {
                            horizontalMovement = speed;
                        }
                    }
                    else if (transform.position.x <= 22)
                    {
                        horizontalMovement = speed;
                    }
                    else if (transform.position.x > 22)
                    {
                        horizontalMovement = speed * -1;
                    }


                    if (jumpPlatform1 == true)
                    {
                        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                        grounded = false;
                        underPlatform = false;
                        if (facingPlayer == false)
                        {
                            Flip();
                        }
                    }
                }
                else if (transform.position.x >= 17 && transform.position.x <= 27)
                {
                    if (flip == false)
                    {
                        if (transform.position.x < 21)
                        {
                            horizontalMovement = speed;
                        }
                        else if (transform.position.x > 23)
                        {
                            horizontalMovement = speed * -1;
                        }
                        else if (transform.position.x >= 21 && transform.position.x <= 23)
                        {
                            flip = true;
                        }
                    }
                    else if (flip == true)
                    {
                        print("test");
                        horizontalMovement = speed * -1;
                        if (jumpPlatform2 == true)
                        {
                            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                            grounded = false;
                            if (facingPlayer == false)
                            {
                                Flip();
                            }
                        }
                        else
                        {

                        }
                    }

                }
            }
        }
        else if (player.platform == "E")
        {

        }
        else if (player.platform == "F")
        {

        }


        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement)); // animation

        if (horizontalMovement > 0 && !facingRight)
        {
            Flip();
        }
        else if (horizontalMovement < 0 && facingRight)
        {
            Flip();
        }

        rb.velocity = new Vector2(horizontalMovement, rb.velocity.y);

        jumpPlatform1 = false;
        jumpPlatform2 = false;
        jumpPlatform3 = false;

    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Recall Collision")
        {
            health -= 2;           
            
        }
        else if(collision.gameObject.tag == "Jump Platform")
        {            
            //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            //grounded = false;
            jumpPlatform1 = true;
        }
        else if (collision.gameObject.tag == "Jump Platform 2")
        {
            //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            //grounded = false;
            print("can jump");
            jumpPlatform2 = true;
        }        
        else if (collision.gameObject.tag == "Jump Platform 3")
        {
            
            jumpPlatform3 = true;
        }
        else if (collision.gameObject.tag == "Platform")
        {
            print("Colliding");
            if (transform.position.y <= 6) // Level 1
            {
                if (transform.position.x < 0) //A
                {
                    platform = "A";
                }
                else if (transform.position.x > 0) //B
                {
                    platform = "B";
                }
            }
            else if (transform.position.y <= 11 && transform.position.y > 6) // Level 2
            {
                if (transform.position.x < -10) //C
                {
                    platform = "C";
                }
                else if (transform.position.x > -10) //D
                {
                    platform = "D";
                }
            }
            else if (transform.position.y > 11) // Level 3
            {
                if (transform.position.x < 10) //E
                {
                    platform = "E";
                }
                else if (transform.position.x > 10) //F
                {
                    platform = "F";
                }

            }
        }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            death.Play();
            var instance = Instantiate(deathParticle, transform.position, transform.rotation);
            //Destroy(instance.gameObject, 1.0f);
            Destroy(gameObject);

        }
        else if (collision.gameObject.tag == "Floor")
        {
            platform = "Null";
        }
    }




}
