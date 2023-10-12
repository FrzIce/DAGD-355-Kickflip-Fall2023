using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner_Alex : MonoBehaviour
{
    public float cooldown = 5f;
    public float Timer;
    public ReticuleControl_Alex rc;
    public GameObject bomba;
    // Start is called before the first frame update
    void Start()
    {
        Timer = 5f;
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
            
            GameObject newBomba = Instantiate(bomba, transform.position, Quaternion.identity);
            Rigidbody2D rb = newBomba.GetComponent<Rigidbody2D>();
            rb.velocity = (rc.transform.position - transform.position);
            //rb.AddForce(new Vector2(lookitx, lookity));
            Timer = 0;
        }
    }
}
