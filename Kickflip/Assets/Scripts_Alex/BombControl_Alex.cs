using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombControl_Alex : MonoBehaviour
{
    private bool stuck;
    public float delay = 2;
    public GameObject bomba_spawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!stuck)
        {
            stuck = true;
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            Debug.Log("bomba hit something!" + stuck);
            StartCoroutine(DeathSequence());
        }
    }

    private IEnumerator DeathSequence()
    {
        float initialScale = transform.localScale.x;
        float targetScale = 0.5f; // The final scale when it shrinks
        float timeToShrink = 1.0f; // Time to shrink
        float timeToExpand = 0.1f; // Time to expand
        float elapsedTime = 0f;

        // Shrink the bomb
        while (elapsedTime < timeToShrink)
        {
            float scale = Mathf.Lerp(initialScale, targetScale, elapsedTime / timeToShrink);
            transform.localScale = new Vector3(scale, scale, 1f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Expand the bomb
        elapsedTime = 0f;
        while (elapsedTime < timeToExpand)
        {
            float scale = Mathf.Lerp(targetScale, initialScale, elapsedTime / timeToExpand);
            transform.localScale = new Vector3(scale, scale, 1f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Destroy this bomb
        Destroy(gameObject);

        // Create smaller bombs in a burst
        for (int i = 0; i < 5; i++)
        {
            Instantiate(bomba_spawn, transform.position, Quaternion.identity);
            Rigidbody2D rb = bomba_spawn.GetComponent<Rigidbody2D>();
            Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            rb.velocity = randomDirection * Random.Range(2f, 5f);
            rb.angularVelocity = Random.Range(-360f, 360f);

        }
    }
}