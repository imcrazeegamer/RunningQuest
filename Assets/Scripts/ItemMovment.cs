using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMovment : MonoBehaviour
{
    public float currentSpeed = 1;
    [SerializeField] EffectedStat effectedStat;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            switch (effectedStat)
            {
                case EffectedStat.Schmekels:
                    ScoreManager.Schmekels++;
                    AudioManager.instance.Play("coin");
                    collision.gameObject.GetComponentInChildren<ParticleSystem>().Play();
                    Destroy(gameObject);
                    break;
                case EffectedStat.Hp:
                    if (player.Hp + 0.2f > 1)
                        player.Hp = 1;
                    else
                        player.Hp += 0.2f;
                    AudioManager.instance.Play("food");
                    Destroy(gameObject);
                    break;
                case EffectedStat.Damage:
                    player.TakeDamage(0.2f);
                    StartCoroutine(AnimateHit());
                    break;
            }
            
        }
    }
    IEnumerator AnimateHit()
    {
        GetComponent<Animator>().Play("IceShardHit");
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
public enum EffectedStat
{
    Schmekels,
    Hp,
    Damage,
}
