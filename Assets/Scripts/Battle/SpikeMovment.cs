using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovment : MonoBehaviour
{
    public float damage = 0.5f;
    [SerializeField] bool isDestroy = false;
    Animator animator;
    
    void Update()
    {
        transform.Translate(Vector2.left  * ScoreManager.GameSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Despawner"))
        {
            Destroy(gameObject);
            //ScoreManager.Schmekels++;
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Player>().TakeDamage(damage);
            if (TryGetComponent(out animator))
            {
                animator.Play("Damage");
            }
            if (isDestroy)
            {
                Destroy(gameObject);
            }
        
        }
    }
    
}
