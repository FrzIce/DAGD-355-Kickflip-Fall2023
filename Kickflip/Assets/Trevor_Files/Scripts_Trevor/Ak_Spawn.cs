using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ak_Spawn : MonoBehaviour
{
    public Player player;

    private float spawnTimerAk = 30;
    public bool usingAk = false; // being used
    public bool onGroundAk = false; // on ground
    public GameObject Ak;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        spawnAK();
    }

    // Update is called once per frame
    void Update()
    {
        if (!usingAk && !onGroundAk)
        {
            if (spawnTimerAk > 0)
            {
                spawnTimerAk -= Time.deltaTime;
            }
            else if (spawnTimerAk < 0)
            {
                spawnAK();
                spawnTimerAk = 30;
            }
        }
    }

    public void spawnAK()
    {
        Instantiate(Ak, transform.position, Quaternion.Euler(0, 0, 45));
        onGroundAk = true;
    }
}
