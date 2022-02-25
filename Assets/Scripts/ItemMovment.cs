using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMovment : MonoBehaviour
{
    public float currentSpeed = 1;
    public Vector2 moveVector = Vector2.left;
    [SerializeField] EffectedStat effectedStat;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveVector * currentSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandleCollision(this, gameObject, effectedStat, collision);
    }
    public static void HandleCollision(MonoBehaviour script,GameObject self,EffectedStat stat, Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            switch (stat)
            {
                case EffectedStat.Schmekels:
                    ScoreManager.Schmekels++;
                    AudioManager.instance.Play("coin");
                    collision.gameObject.GetComponentInChildren<ParticleSystem>().Play();
                    Destroy(self);
                    break;
                case EffectedStat.Hp:
                    if (player.Hp + 0.2f > 1)
                        player.Hp = 1;
                    else
                        player.Hp += 0.2f;
                    AudioManager.instance.Play("food");
                    Destroy(self);
                    break;
                case EffectedStat.Damage:
                    player.TakeDamage(0.2f);
                    script.StartCoroutine(AnimateHit(self));
                    break;
            }

        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(self);
        }
    }
    public static IEnumerator AnimateHit(GameObject self)
    {
        self.GetComponent<Animator>().Play("IceShardHit");
        yield return new WaitForSeconds(2f);
        Destroy(self);
    }
}
public enum EffectedStat
{
    Schmekels,
    Hp,
    Damage,
}
