using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{
    int enemyType;
    float spawnTimer = 5;

    public GameObject Enemy_Trevor;
    public Enemy script;
    public GameObject obj;
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

        print("spawning " + enemyType);
        
        obj = Instantiate(Enemy_Trevor, transform.position, Quaternion.identity);        
        spawnTimer = 5;
        enemyRandomizer(obj);
    }

    public void enemyRandomizer(GameObject me)
    {
        script = me.GetComponent<Enemy>();
        enemyType = Random.Range(0, 2);
        if (enemyType == 1)
        {
            script.isFlier = true;
        }
        if (enemyType == 0)
        {
            script.isFlier = false;
        }
    }
}
