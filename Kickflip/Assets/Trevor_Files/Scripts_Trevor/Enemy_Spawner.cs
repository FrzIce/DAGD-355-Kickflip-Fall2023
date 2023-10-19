using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    int enemyType;
    float spawnTimer = 5;

    public GameObject Enemy_Trevor;
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        enemyType = Random.Range(0, 1);
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
        obj = Instantiate(Enemy_Trevor, transform.position, Quaternion.identity);        
        spawnTimer = 5;
    }
}
