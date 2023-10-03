using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletSpawner_Alex : MonoBehaviour
{
    public int mag = 12;
    public float Timer;
    public float reloadTime = 2f;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(mag + " bullets left");
        if (Timer <= reloadTime)
        {
            Debug.Log("reloading " + Timer);
            Timer += Time.deltaTime;
            if (Timer >= reloadTime)
            {
                mag = 12;
            }
        }

        if (Input.GetMouseButtonDown(0) && mag != 0)
        {
            Quaternion currentRot = transform.rotation;
            GameObject newBullet = Instantiate(bullet, transform.position, currentRot);
            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
            rb.velocity = -transform.up * 10f;
            //rb.AddForce(new Vector2(lookitx, lookity));
            mag--;
            if (mag == 0)
            {
                Timer = 0;
            }
        }
    }
}
