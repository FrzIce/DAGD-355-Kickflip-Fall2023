using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl_Alex : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        
    }
}

