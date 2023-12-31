using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion_Spawns : MonoBehaviour
{
    public Player player;
    
    private float spawnTimer = 15;
    public bool potionAlive = false;    
    public GameObject HealthPotion;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        spawn();     
    }

    // Update is called once per frame
    void Update()
    {
        if (!potionAlive)
        {
            if (spawnTimer > 0)
            {
                spawnTimer -= Time.deltaTime;
            }
            else if (spawnTimer < 0)
            {
                spawn();
                spawnTimer = 15;
            }
        }
    }

    public void spawn()
    {
        Instantiate(HealthPotion, transform.position, Quaternion.Euler(0, 0, -45));
        potionAlive = true;
    }

    
}
