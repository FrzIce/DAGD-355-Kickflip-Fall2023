using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner_Alex : MonoBehaviour
{
    public float cooldown = 5f;
    public float Timer;
    public ReticuleControl_Alex rc;
    public GameObject bomba;
    public BombControl_Alex bombAI;

    public AudioSource launch;
    public AudioSource splode;
    // Start is called before the first frame update
    void Start()
    {
        Timer = 5f;
        bombAI = bomba.GetComponent<BombControl_Alex>();
        rc = GameObject.FindGameObjectWithTag("reticule").GetComponent<ReticuleControl_Alex>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer <= cooldown)
        {
            Timer += Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(1) && Timer >= cooldown)
        {
            launch.Play();
            GameObject newBomba = Instantiate(bomba, transform.position, Quaternion.identity);
            Rigidbody2D rb = newBomba.GetComponent<Rigidbody2D>();
            rb.velocity = (rc.transform.position - transform.position);
            BombControl_Alex bc = newBomba.GetComponent<BombControl_Alex>();
           // Splosion(bc);
            Timer = 0;
        }

        //Debug.Log("Stuck = " + bombAI.stuck);
        if (bombAI.stuck == true)
        {
           // splode.Play();
        }
    }

   /* private void Splosion(BombControl_Alex bAI)
    {
        if(bAI.stuck == true)
        {
            Debug.Log("bomb has been planted");
        }
        splode.Play();           
    }*/
}
