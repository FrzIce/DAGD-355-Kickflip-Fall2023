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

    [SerializeField]
    public Image imageCooldown;
    [SerializeField]
    public TMP_Text textCooldown;

    


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        

        //colldown icon
        textCooldown.gameObject.SetActive(false);
        imageCooldown.fillAmount = 0.0f;

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
