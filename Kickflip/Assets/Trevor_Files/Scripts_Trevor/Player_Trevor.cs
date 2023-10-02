using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{

    [SerializeField]
    private Image imageCooldown;
    [SerializeField]
    private TMP_Text textCooldown;


    private Rigidbody2D rb;
    public int health = 3;
    public bool alive;
    public float jumpForce = 5;
    public float speed = 5;
    public float horizontalMovement;
    public float verticalMovement;
    public bool grounded;

    //calling scripts so we can get codes from other objects - 1
    //public RecallCollision_Trevor recall;
    public LogicScript_Trevor logic;

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
        textCooldown = GetComponent<TextMeshPro>();

        alive = true;
        recallSet = false;
        recallCD = 10;
        rb = GetComponent<Rigidbody2D>();

        //colldown icon
        textCooldown.gameObject.SetActive(false);
        imageCooldown.fillAmount = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        //Ends Game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }        

        if (health <= 0) // Checks if player is dead
        {
            alive = false;
            Destroy(gameObject);
        }

        //Movement help
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        horizontalMovement = (h * speed);


        if (alive)
        {
            

            //Recall set and recall
            if (Input.GetKeyDown(KeyCode.E))
            {
                if((recallSet == false) && (recallReady == true))
                {
                    recallPoint = transform.position;
                    recallSet = true;
                    recallReady = false;
                    recallCD = 0;
                }
                else if (recallSet == true)
                {
                    transform.position = recallPoint;
                    recallSet = false;
                    recallPoint = new Vector2(0, 0);
                    explosion = true;
                    logic.explosionActive();
                }                
            }



            // Jumping
            if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                grounded = false;
            }
            // Movement
            rb.velocity = new Vector2(horizontalMovement, rb.velocity.y);


            // Recall Cooldown - will be active when recall is cooling down - 10 sec
            if((recallCD < 10) && (recallSet == false) && (recallReady == false))
            {
                ApplyCooldown();
            }
            else if (recallCD >= 10)
            {
                recallReady = true;
                textCooldown.gameObject.SetActive(false);
                imageCooldown.fillAmount = 0.0f;
            }
            //print(recallCD); // Debug
        }

        


    }

    void ApplyCooldown()
    {
        //subtrack time since last called
        recallCD += Time.deltaTime;
        textCooldown.text = Mathf.RoundToInt(recallCD).ToString();
        imageCooldown.fillAmount = recallCD / 10f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Kill Zone")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Platform")
        {
            grounded = true;
        }
        else if (collision.gameObject.tag == "Floor")
        {
            grounded = true;
        }

    }
}
