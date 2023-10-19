using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;

public class AudioManage : MonoBehaviour
{


    public AudioSource enemy_Death;
    
    // Start is called before the first frame update
    void Start()
    {
        enemy_Death = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enemyDeath()
    {
        enemy_Death.Play();
    }
}
