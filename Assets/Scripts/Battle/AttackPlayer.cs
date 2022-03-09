using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    
    [SerializeField] bool isMelee = true;
    [SerializeField] float attackRange = 100f;
    [SerializeField] float attackWait = 0.5f;
    [SerializeField] float attackSpeed = 1f;

    bool canAttack;
    Player player;
    float playerDistance;
    Animator animator;
    void Start()
    {
        player = FindObjectOfType<Player>();
        animator = GetComponent<Animator>();
        int heatValue = HeatHandler.GetHeatValue(HeatType.StrogerFoes);
        canAttack = heatValue > 2;
        attackWait = heatValue > 4 ? attackWait * (1 / heatValue) : attackWait;
        attackSpeed = heatValue > 4 ? attackWait * (1 / heatValue) : attackWait;
        animator.SetFloat("AttackSpeed", attackSpeed);
        animator.SetFloat("AttackWait", attackWait);

    }

    void FixedUpdate()
    {
        if (canAttack)
        {
            playerDistance = Vector2.Distance(transform.position, player.transform.position);
            if (playerDistance <= attackRange)
            {
                if (isMelee)
                {
                    StartCoroutine(Attack());
                }
            }
        }
    }
    IEnumerator Attack()
    {
        //Debug.Log("attacking Player");
        animator.SetBool("isAttack", true);
        yield return new WaitForSeconds(attackWait);
        
    }
    public void ResetAnimation()
    {
        animator.SetBool("isAttack", false);
    }
}
