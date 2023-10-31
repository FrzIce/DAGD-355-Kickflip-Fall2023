using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;

public class UI_Trevor : MonoBehaviour
{
    public Player player;
    public BulletSpawner_Alex bulletSpawner;
    
    //recall
    [SerializeField]
    public Image Recall_imageCooldown;
    [SerializeField]
    public TMP_Text Recall_textCooldown;

    //health
    [SerializeField]
    public TMP_Text health_text;

    //ammo
    [SerializeField]
    public TMP_Text ammo_text;





    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        bulletSpawner = GameObject.FindGameObjectWithTag("gun").GetComponent<BulletSpawner_Alex>();


        //colldown icon
        Recall_textCooldown.gameObject.SetActive(false);
        Recall_imageCooldown.fillAmount = 0.0f;

        //health first
        health_text.text = Mathf.RoundToInt(player.health).ToString();

        //ammo
        ammo_text.text = Mathf.RoundToInt(bulletSpawner.mag).ToString();



        

    }

    // Update is called once per frame
    void Update()
    {
        //health
        health_text.text = Mathf.RoundToInt(player.health).ToString();

        //ammo
        if(bulletSpawner.mag <= 0)
        {
            ammo_text.text = "Reloading";
        }
        else
        {
            ammo_text.text = Mathf.RoundToInt(bulletSpawner.mag).ToString();
        }

        
    }

    public void setRecall() 
    {
        Recall_textCooldown.gameObject.SetActive(true);
        Recall_textCooldown.text = "Set";
    }

    public void recallReady()
    {
        Recall_textCooldown.gameObject.SetActive(false);
        Recall_imageCooldown.fillAmount = 0.0f;
    }

    public void ApplyCooldown()
    {
        //subtrack time since last called
        player.recallCD -= Time.deltaTime;
        if (Recall_textCooldown == true)
        {
            Recall_textCooldown.text = Mathf.RoundToInt(player.recallCD).ToString();
        }
        Recall_imageCooldown.fillAmount = player.recallCD / 10f;
    }
}
