using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recall_Marker_Trevor : MonoBehaviour
{
    public Player player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void Update()
    {
        if (player.recallSet == false)
        {
            Destroy(gameObject);
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
