using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//this is the code for the explosion after the recall
public class RecallCollision_Trevor : MonoBehaviour
{ 

    //calling scripts so we can get codes from other objects - 1
    public Player player;
    public Enemy enemy;
    public LogicScript_Trevor logic;
    public Animator animator;

    public AudioSource recall;

    //public bool explosion; // when this is active then the object can collide and will be active for 1 secs after recalls
    public float explosionTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //calling scripts so we can get codes from other objects - 2
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript_Trevor>();
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();

        recall = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if (player.explosion == true)
        {
            if (explosionTimer == 0)
            {
                recall.Play();
            }
            if (explosionTimer < 1)
            {
                explosionTimer += Time.deltaTime;
            }
            else if (explosionTimer >= 1)
            {
                explosionTimer = 0;
                player.explosion = false;
                logic.explosionDeActivate();
                animator.SetBool("Recall", false);
            }
        }
        //print(explosionTimer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.tag == "Enemy")
        //{
        //    enemy.health -= 2;
        //}
    }

    

    
}
