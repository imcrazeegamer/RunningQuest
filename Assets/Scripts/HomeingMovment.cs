using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeingMovment : MonoBehaviour
{
    public float speed = 1;
    public Vector3 targetPos;
    [SerializeField] EffectedStat effectedStat;
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetPos.x, 0, 0), speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemMovment.HandleCollision(this, gameObject, effectedStat, collision);
        
    }
}
