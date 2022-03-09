using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    Vector2 dest = new Vector2(-1, 0.5f);
    bool moveing = true;
    Animator animator;
    float speed = 0.5f;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    { 
        if (moveing)
        {
            transform.position = Vector2.MoveTowards(transform.position, dest, Time.deltaTime * ScoreManager.GameSpeed * speed);
            moveing = (Vector2)transform.position != dest;
        }
        else
        {
            animator.SetBool("isAttack", true);
        }
    }
    public void EndAttack()
    {
        animator.SetBool("isAttack", false);
        moveing = true;
        speed = 2f;
        dest = new Vector2(-1, 100f);
    }
}
