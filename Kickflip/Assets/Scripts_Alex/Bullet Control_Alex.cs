using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl_Alex : MonoBehaviour
{
  
    public int bulletSpeed = 100;
    public GameObject sprite;
    

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
        //Destroy(gameObject);
    }
}

