using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] GameObject gameOverOverlay;
    public Vector2 velocity;
    public float jumpVelocity = 20;
    public bool isGrounded = false;
    float health = 1;
    public float Hp { get => health; set => health = value; }
    Rigidbody2D rb;
    Animator animator;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (health <= 0)
        {
            gameOverOverlay.SetActive(true);
            
        }
        if ((Input.touchCount > 0 || Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(Vector2.up * jumpVelocity);
            AudioManager.instance.Play("jump");
        }
        ScoreManager.Distance += Time.deltaTime;
        animator.SetBool("IsJumping", !isGrounded);
    } 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (!isGrounded)
            {
                isGrounded = true;
            }
        }
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        Animator a;
        if (TryGetComponent(out a))
        {
            a.Play("Damage");
        }
        AudioManager.instance.Play("damage");
        //Debug.Log($"Player HP: {health}");
    }
}
