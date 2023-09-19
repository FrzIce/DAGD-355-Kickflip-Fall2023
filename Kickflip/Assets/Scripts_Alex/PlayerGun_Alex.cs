using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerGun_Alex : MonoBehaviour
{
    public Vector3 screenPosition;
    public Vector3 worldPosition;
    public GameObject Player;
    public GameObject Reticule;

    // Start is called before the first frame update
    void Start()
    {
       // Instantiate(Player, new Vector3(0,0), Quaternion.identity);
       // Instantiate(Reticule, Reticule.transform.position, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        screenPosition = Input.mousePosition;
       
        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        Reticule.transform.position = worldPosition;

        //Reticule.transform.position = Input.mousePosition;

        Player.transform.rotation = Quaternion.identity;
   
    }
}
