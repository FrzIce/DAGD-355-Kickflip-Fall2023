using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner_Alex : MonoBehaviour
{
    public GameObject bomba;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Quaternion currentRot = transform.rotation;
            GameObject newBomba = Instantiate(bomba, transform.position, currentRot);
            Rigidbody2D rb = newBomba.GetComponent<Rigidbody2D>();
            rb.velocity = -transform.up * 10f;
            //rb.AddForce(new Vector2(lookitx, lookity));
        }
    }
}
