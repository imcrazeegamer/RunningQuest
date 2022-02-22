using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Vector2 velocity;
    public float jumpVelocity = 20;
    public bool isGrounded = false;
    float health = 1;
    public float Hp { get => health; }
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

            if (ScoreManager.Distance > ScoreManager.__HiDistance)
            {
                ScoreManager.__HiDistance = ScoreManager.Distance;
            }
            ScoreManager.SaveScore();
            ScoreManager.Schmekels = 0;
            ScoreManager.Distance = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if ((Input.touchCount > 0 || Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(Vector2.up * jumpVelocity);
            //Debug.Log("Jump");
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
        Debug.Log($"Player HP: {health}");
    }
}
