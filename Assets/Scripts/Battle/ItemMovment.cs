using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMovment : MonoBehaviour
{
    public Vector2 moveVector = Vector2.left;
    [SerializeField] EffectedStat effectedStat;
    [SerializeField] float Speed = 1;
    [SerializeField] GameObject popupPrefab;
    void Update()
    {
        transform.Translate(moveVector * ScoreManager.GameSpeed * Speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandleCollision(this, gameObject, effectedStat, collision, popupPrefab);
    }
    public static void HandleCollision(MonoBehaviour script, GameObject self, EffectedStat stat, Collider2D collision, GameObject prefabPopup = null)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            switch (stat)
            {
                case EffectedStat.Schmekels:
                    ScoreManager.Schmekels++;
                    AudioManager.instance.Play("coin");
                    DamagePopup.Create(prefabPopup, self.transform.position, 1, true);
                    collision.gameObject.GetComponentInChildren<ParticleSystem>().Play();
                    Destroy(self);
                    break;
                case EffectedStat.SchmekelsUltra:
                    ScoreManager.Schmekels += 10;
                    AudioManager.instance.Play("coin");
                    DamagePopup.Create(prefabPopup, self.transform.position, 10, true);
                    collision.gameObject.GetComponentInChildren<ParticleSystem>().Play();
                    Destroy(self);
                    break;
                case EffectedStat.Hp:
                    player.Heal(0.2f); 
                    AudioManager.instance.Play("food");
                    Destroy(self);
                    break;
                case EffectedStat.Damage:
                    player.TakeDamage(0.2f);
                    Collider2D collider = self.GetComponent<Collider2D>();
                    collider.enabled = false;
                    script.StartCoroutine(AnimateHit(self));
                    break;
                case EffectedStat.Sheild:
                    player.TurnOnSheild();
                    Destroy(self);
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
    SchmekelsUltra,
    Hp,
    Damage,
    Sheild,
}
