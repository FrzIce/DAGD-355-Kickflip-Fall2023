using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl_Alex : MonoBehaviour
{
    public GameObject crosshair;
    public GameObject bullet;
    public Image img;
    public int bulletSpeed = 100;
    public ReticuleControl_Alex rc;
    private float lookitx;
    private float lookity;

    // Start is called before the first frame update
    void Start()
    {
        rc = GameObject.FindGameObjectWithTag("reticule").GetComponent<ReticuleControl_Alex>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        lookitx = rc.transform.position.x;
        lookity = rc.transform.position.y;
        
        if (lookitx != 0)
        {
            float angle = Mathf.Atan2(lookitx, lookity) * Mathf.Rad2Deg;
            Quaternion newRotation = Quaternion.Euler(0, 0, -angle - 180);
            transform.rotation = newRotation;
        }

        if (transform.rotation.z > 180)
        {
            //figure this out later
            //img.flip
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(bullet, transform);
            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
            rb.velocity = -transform.up * bulletSpeed;
        }


    }

    private void OnMouseDown()
    {
       
        
        //float angle
    }
}
