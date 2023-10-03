using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner_Alex : MonoBehaviour
{
    public float cooldown = 5f;
    public float Timer;
    public GameObject bomba;
    // Start is called before the first frame update
    void Start()
    {
        Timer = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer <= cooldown)
        {
            Timer += Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(1) && Timer >= cooldown)
        {
            Quaternion currentRot = transform.rotation;
            GameObject newBomba = Instantiate(bomba, transform.position, currentRot);
            Rigidbody2D rb = newBomba.GetComponent<Rigidbody2D>();
            rb.velocity = -transform.up * 10f;
            //rb.AddForce(new Vector2(lookitx, lookity));
            Timer = 0;
        }
    }
}
