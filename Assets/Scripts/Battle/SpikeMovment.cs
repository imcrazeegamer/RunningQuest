using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovment : MonoBehaviour
{
    public float damage = 0.5f;
    [SerializeField] bool isDestroy = false;
    bool isMoveVertical = false;
    [SerializeField] bool isMoveVerticalAllowed = false;
    Animator animator;
    float min = 0.1f;
    float max = 0.5f;
    float yDir;
    bool up;


    private void Start()
    {
        isMoveVertical = HeatHandler.GetHeatValue(HeatType.StrogerFoes) > 0;
        yDir = Random.Range(min, max);
        up = Random.Range(0f, 1f) > 0.5f;
    }
    void FixedUpdate()
    {
        
        if (isMoveVertical && isMoveVerticalAllowed)
        {
  
            if (yDir >= max)
            {
                yDir = max;
                up = false;
            }
            if (yDir <= min)
            {
                yDir = min;
                up = true;
            }

            int dir = up ? 1 : -1;
            yDir += dir * 0.1f * Time.deltaTime;
            transform.position = new Vector2(transform.position.x - Time.deltaTime * ScoreManager.GameSpeed, yDir);
        }
        else
        {
            transform.Translate(Vector2.left * ScoreManager.GameSpeed * Time.deltaTime);
        }
        
        
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
