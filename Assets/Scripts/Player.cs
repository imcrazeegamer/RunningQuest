using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] GameObject damagePopupPrefab;
    [SerializeField] GameObject gameOverOverlay;
    [SerializeField] GameObject pauseOverlay;
    [SerializeField] GameObject pauseBtn;
    [SerializeField] Transform Shield;
    
    public float jumpVelocity = 20;
    public int maxJumps = 1;
    public float hpRegen = 0;

    bool isShield = false;
    int currentJumps;
    float health = 1;
    public float Hp { get => health; set => health = value; }
    Rigidbody2D rb;
    Animator animator;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentJumps = maxJumps;
    }
    private void Start()
    {
        AudioManager.instance.Play("music");
    }
    void Update()
    {
        if (health <= 0)
        {
            pauseBtn.SetActive(false);
            gameOverOverlay.SetActive(true);

        }
        HpRegen();
        if ((Input.touchCount > 0 || Input.GetKeyDown(KeyCode.Space)) && currentJumps >= 1)
        {
            //isGrounded = false;
            
            rb.AddForce(Vector2.up * jumpVelocity * jumpMod());
            AudioManager.instance.Play("jump");
            currentJumps--;
        }
        ScoreManager.Distance += Time.deltaTime * ScoreManager.GameSpeed/2;
        animator.SetBool("IsJumping", currentJumps != maxJumps);
       if (Input.GetKeyDown(KeyCode.Escape))
       {
            pauseOverlay.SetActive(true);
       }
    }
    private float jumpMod()
    {
        if(currentJumps == maxJumps)
        {
            return 1;
        }
        if(currentJumps < maxJumps)
        {
            return 0.5f;
            //return currentJumps / maxJumps;
        }
        return 0.5f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            currentJumps = maxJumps;
        }
    }
    public void TakeDamage(float amount)
    {
        if (isShield)
        {
            Shield.gameObject.SetActive(false);
            isShield = false;
        }
        else
        {
            amount += amount * 0.1f * HeatHandler.GetHeatValue(HeatType.DamageTaken);
            health -= amount;
            DamagePopup.Create(damagePopupPrefab, transform.position,(int)(amount * 100));
            Animator a;
            if (TryGetComponent(out a))
            {
                a.Play("Damage");
            }
            AudioManager.instance.Play("damage");
        }
        //Debug.Log($"Player HP: {health}");
    }
    public void Heal(float amount)
    {
        amount -= amount * HeatHandler.GetHeatValue(HeatType.HealAmount) * 0.1f;
        if (health + amount > 1)
        {
            health = 1;
        }
        else if (health < 1)
        {
            health += amount;
        }
    }
    void HpRegen()
    {
        Heal(hpRegen * Time.deltaTime);
        
    }
    public void TurnOnSheild()
    {
        isShield = true;
        Shield.gameObject.SetActive(isShield);
    }
}
