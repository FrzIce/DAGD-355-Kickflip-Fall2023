using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticuleControl_Alex : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector3 screenPosition;
    public Vector3 worldPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        screenPosition = Input.mousePosition;

        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        rb.transform.position = worldPosition;
    }
}
