using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potion_Trevor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position= new Vector2(transform.position.x, transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
