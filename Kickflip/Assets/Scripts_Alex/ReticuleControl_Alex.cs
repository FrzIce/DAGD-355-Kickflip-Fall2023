using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticuleControl_Alex : MonoBehaviour
{
    public Vector3 screenPosition;
    public Vector3 worldPosition;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        screenPosition = Input.mousePosition;

        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        transform.position = worldPosition;
        transform.position += new Vector3(0,0,10f);
    }
}
