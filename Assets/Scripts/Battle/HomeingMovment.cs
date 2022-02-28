using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeingMovment : MonoBehaviour
{
    public Vector3 targetPos;
    public float Speed = 1;
    [SerializeField] EffectedStat effectedStat;
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetPos.x, 0, 0), ScoreManager.GameSpeed * Speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemMovment.HandleCollision(this, gameObject, effectedStat, collision);
        
    }
}
