using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletSpawner_Alex : MonoBehaviour
{

    public Ak_Spawn spawnAk;
    public int mag = 12;
    public float Timer;
    public float reloadTime = 2f;
    public float bigShootTimer = 5f;
    public float AKTimer;
    public GameObject bullet;
    public ReticuleControl_Alex rc;
    public bool hasAK;
    public float bulletSpeed = 1f;
    private bool holdClick;
    private Animator anime;

    public AudioSource gun;
    public AudioSource reload;
    public AudioSource ak;
    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
        rc = GameObject.FindGameObjectWithTag("reticule").GetComponent<ReticuleControl_Alex>();
        spawnAk = GameObject.FindGameObjectWithTag("Ak_Spawner").GetComponent<Ak_Spawn>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            holdClick = true;
            anime.SetBool("isAttacking", true);
        }
        if(Input.GetMouseButtonUp(0))
        {
            holdClick = false;
            anime.SetBool("isAttacking", false);
        }

        if (hasAK)
        {
            if(AKTimer < bigShootTimer)
            {
                Debug.Log("time spent with AK " + AKTimer);
                AKTimer += Time.deltaTime;
                if(AKTimer >= bigShootTimer)
                {
                    spawnAk.usingAk = false;
                    hasAK = false;
                    AKTimer = 0;
                    mag = 12;
                }
            }

        }

        if (Timer <= reloadTime)
        {
            
            //Debug.Log("reloading " + Timer);
            Timer += Time.deltaTime;
            if(Timer >= reloadTime && !hasAK)
            {
                mag = 12;
            }
        }

        if (Input.GetMouseButtonDown(0) && mag != 0 && !hasAK)
        {
            gun.Play();
            GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
            rb.velocity = (rc.transform.position - transform.position) * bulletSpeed;
            mag--;
            if (mag == 0)
            {
                Timer = 0f;
                reload.Play();
            }
        } 

        if (Input.GetMouseButtonDown(0) && hasAK){
            ak.Play();
        }
        if (Input.GetMouseButtonUp(0) || !hasAK)
        {
            ak.Stop();
        }

        if (holdClick && mag != 0 && hasAK)
        {
           GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
           Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
           rb.velocity = (rc.transform.position - transform.position) * bulletSpeed;
        }
    }
}
