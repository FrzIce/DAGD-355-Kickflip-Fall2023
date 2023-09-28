using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner_Alex : MonoBehaviour
{
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Quaternion currentRot = transform.rotation;
            GameObject newBullet = Instantiate(bullet, transform.position, currentRot);
            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
            rb.velocity = -transform.up * 10f;
            //rb.AddForce(new Vector2(lookitx, lookity));
        }
    }
}
