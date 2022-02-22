using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovment : MonoBehaviour
{
    public float damage = 0.5f;
    public float currentSpeed;

    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("NextSpikeSpawn");
        if (collision.gameObject.CompareTag("Despawner"))
        {
            Destroy(gameObject);
            ScoreManager.Schmekels++;
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Player>().TakeDamage(damage);
        }
    }
}
