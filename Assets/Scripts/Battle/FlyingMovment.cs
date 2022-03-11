using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMovment : MonoBehaviour
{
    public float currentSpeed = 1;
    public Vector2 moveVector = Vector2.left;
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject popupPrefab;
    float timeBtwSpawn = 2f;
    [SerializeField] [Range(0.1f, 10f)] float startTimeMin = 1f;
    [SerializeField] [Range(1f, 10f)] float startTimeMax = 10f;
    [SerializeField] bool destroyOnPlayerCollision = false;
    bool upgraded;
    void Start()
    {
        upgraded = HeatHandler.GetHeatValue(HeatType.StrogerFoes) >= 8;
        startTimeMin /= ScoreManager.GameSpeed;
        startTimeMax /= ScoreManager.GameSpeed;
    }
    void FixedUpdate()
    {
        transform.Translate(moveVector * currentSpeed * Time.deltaTime * ScoreManager.GameSpeed);
        if (timeBtwSpawn <= 0)
        {
            Animator a = GetComponent<Animator>();
            a.SetTrigger("Charge");
            //GenarateProjectile();
            timeBtwSpawn = Random.Range(startTimeMin, startTimeMax);
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
    public void GenarateProjectile()
    {
        
        
        Vector3 from = transform.position + new Vector3(-0.3f, -0.3f, 0);
        Vector3 to = FindObjectOfType<Player>().transform.position;
        projectile.GetComponent<HomeingMovment>().targetPos = to;

        Instantiate(projectile, from, Quaternion.identity, transform);

        if (upgraded)
        {
            Instantiate(projectile, transform.position + new Vector3(-0.1f, -0.6f, 0), Quaternion.identity, transform);
            Instantiate(projectile, transform.position + new Vector3(-0.5f,  0f, 0), Quaternion.identity, transform);
        }

    }
    

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (destroyOnPlayerCollision)
            {
                ScoreManager.AddSchmekels(15);
                DamagePopup.Create(popupPrefab, gameObject.transform.position, ScoreManager.SchmekelCalc(15), true);
                Destroy(gameObject);
            }
            else
            {
                collision.gameObject.GetComponent<Player>().TakeDamage(0.3f);
            }
        }
    }
}
