using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{

    //[SerializeField]
    //public Image imageCooldown;
    //[SerializeField]
    //public TMP_Text textCooldown;

    //calling scripts so we can get codes from other objects - 1
    public Animator animator;
    public LogicScript_Trevor logic;
    public GameObject explosionParticle;
    public GameObject recallMarker;
    public potion_Trevor potion;
    public GameObject healthPotion;
    public BulletSpawner_Alex bulletSpawn;

    public Potion_Spawns spawnPotion;
    public Ak_Spawn spawnAk;
    public AudioSource health_Potion;
    public Recall_Marker_Trevor recall_Marker;

   


    public UI_Trevor UI;

    private Rigidbody2D rb;
    public int health;
    public int maxHealth = 3;
    public bool alive;
    public float jumpForce = 5;
    public float speed = 5;
    public float horizontalMovement;
    public float verticalMovement;
    public bool grounded;
    bool facingRight = true;


    //Player platforms and AI uasage
    public string platform = "Null";



    ////State animation variables
    public float injureTimer = 0;

    

    //Recall Variables
    //public RecallCollision_Trevor recall;
    public bool recallSet;
    public Vector2 recallPoint;
    public float recallCD;
    public bool recallReady;
    public bool explosion = false;


    // Start is called before the first frame update
    void Start()
    {
        //calling scripts so we can get codes from other objects - 2
        //recall = GameObject.FindGameObjectWithTag("Recall Collision").GetComponent<RecallCollision_Trevor>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript_Trevor>();
        spawnPotion = GameObject.FindGameObjectWithTag("potion_Spawner").GetComponent<Potion_Spawns>();
        spawnAk = GameObject.FindGameObjectWithTag("Ak_Spawner").GetComponent<Ak_Spawn>();
        bulletSpawn = GameObject.FindGameObjectWithTag("gun").GetComponent<BulletSpawner_Alex>();

        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        //textCooldown = GetComponent<TextMeshPro>();
        
        UI = GameObject.FindGameObjectWithTag("Canvas").GetComponent<UI_Trevor>();

        health = maxHealth;
        alive = true;
        recallSet = false;
        recallCD = 10;
        rb = GetComponent<Rigidbody2D>();

        health_Potion = GetComponent<AudioSource>();



        //colldown icon
        //textCooldown.gameObject.SetActive(false);
        //imageCooldown.fillAmount = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //print("test");
        
        //print(transform.position.x);
        //print(transform.position.y);
        //print(animator.GetFloat("Speed"));

        //Ends Game
        

        if (health <= 0) // Checks if player is dead
        {
            alive = false;
            Destroy(gameObject);
            logic.endGame();
        }

        //Movement help

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        horizontalMovement = (h * speed);

        if(injureTimer >= .8)
        {
            notInjured();
        }
        else if (injureTimer < .8)
        {
            injureTimer += Time.deltaTime;
        }
        

        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));


        if (alive)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                animator.SetBool("isAttacking", true);
            }
            if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
            {
                animator.SetBool("isAttacking", false);
            }

            //Recall set and recall
            if (Input.GetKeyDown(KeyCode.E))
            {
                if ((recallSet == false) && (recallReady == true))
                {
                    recallPoint = transform.position;
                    Instantiate(recallMarker, recallPoint, Quaternion.identity);
                    recallSet = true;
                    recallReady = false;
                    recallCD = 0;
                    UI.Recall_textCooldown.gameObject.SetActive(true);
                    UI.Recall_textCooldown.text = "Set";
                }
                else if (recallSet == true)
                {
                    animator.SetBool("Recall", true);
                    transform.position = recallPoint;
                    recallSet = false;
                    recallPoint = new Vector2(0, 0);
                    explosion = true;
                    logic.explosionActive();
                    Instantiate(explosionParticle, transform.position, transform.rotation);
                }
            }

            if (horizontalMovement > 0 && !facingRight)
            {
                Flip();
            }
            else if (horizontalMovement < 0 && facingRight)
            {
                Flip();
            }


            // Movement
            rb.velocity = new Vector2(horizontalMovement, rb.velocity.y);
            // Jumping
            if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                grounded = false;
                animator.SetBool("IsJumping", true);
            }



            // Recall Cooldown - will be active when recall is cooling down - 10 sec
            if ((recallCD < 10) && (recallSet == false) && (recallReady == false))
            {
                UI.ApplyCooldown();
            }
            else if (recallCD >= 10)
            {
                recallReady = true;
                UI.recallReady();
            }
            //print(recallCD); // Debug
        }




    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }

    void notInjured()
    {
        animator.SetBool("Injured", false);
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Kill Zone")
        {
            health = 0;
        }
        else if (collision.gameObject.tag == "Platform")
        {            
            
            if ((transform.position.y <= 3 && transform.position.y >= 0) || (transform.position.y <= 8 && transform.position.y >= 5) || (transform.position.y <= 13 && transform.position.y >= 10))
            {
                grounded = true;
                animator.SetBool("IsJumping", false);
            }
        }
        else if (collision.gameObject.tag == "Floor")
        {
            platform = "Null";
            grounded = true;
            animator.SetBool("IsJumping", false);

        }
        else if (collision.gameObject.tag == "Enemy")
        {
            health -= 1;
            injureTimer = 0;
            animator.SetBool("Injured", true);
            
            //rb.velocity = new Vector2(0, rb.velocity.y + 5);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Potion")
        {
            if (health >= maxHealth)
            {

            }
            else
            {
                health_Potion.Play();
                spawnPotion.potionAlive = false;
                Destroy(GameObject.FindGameObjectWithTag("Potion"));                
                health += 1;
                
            }

        }

        if (collision.gameObject.tag == "AK")
        {
            Destroy(GameObject.FindGameObjectWithTag("AK"));
            bulletSpawn.hasAK = true;
            spawnAk.onGroundAk = false;
            spawnAk.usingAk = true;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            health -= 1;
            injureTimer = 0;
            animator.SetBool("Injured", true);

            //rb.velocity = new Vector2(0, rb.velocity.y + 5);
        }

        //upgraded AI?

        //else if (collision.gameObject.tag != "Platform")
        //{
        //    platform = "Null";
        //}

        if (collision.gameObject.tag == "Platform")
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

        

        //if (collision.gameObject.tag == "Floor")
        //{
        //    platform = "Null";
        //}
    }
}
