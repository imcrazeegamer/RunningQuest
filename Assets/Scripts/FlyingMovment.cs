using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMovment : MonoBehaviour
{
    public float currentSpeed = 1;
    public Vector2 moveVector = Vector2.left;
    [SerializeField] GameObject projectile;
    float timeBtwSpawn = 2f;
    [SerializeField] [Range(0.1f, 10f)] float startTimeMin = 1f;
    [SerializeField] [Range(1f, 10f)] float startTimeMax = 10f;
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        transform.Translate(moveVector * currentSpeed * Time.deltaTime);
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
        
        //yield return new WaitForSeconds(1f);
        //a.SetBool("isCharging", false);
        Vector3 from = transform.position + new Vector3(-0.3f, -0.3f, 0);
        Vector3 to = FindObjectOfType<Player>().transform.position;
        //Vector3 dir = to - from;
        projectile.GetComponent<HomeingMovment>().targetPos = to;

        var p = Instantiate(projectile, from, Quaternion.identity, transform);
        //p.transform.LookAt(to);
        //float rot_z = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //p.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        //var r = p.transform.rotation;
        //p.transform.rotation = new Quaternion(0, 0, r.x, r.w);

    }
}
