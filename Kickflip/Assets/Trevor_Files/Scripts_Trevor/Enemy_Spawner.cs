using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    int enemyType = Random.Range(0, 1);
    float spawnTimer = 5;

    public GameObject Enemy_Trevor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;  
        if (spawnTimer < 0)
        {
            spawnEnemy();
        }
    }

    public void spawnEnemy()
    {
        print("spawning");
        enemyType = Random.Range(0, 1);        
        Instantiate(Enemy_Trevor, transform.position, Quaternion.identity);
        spawnTimer = 5;
    }
}
