using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinClick : MonoBehaviour
{
    public ParticleSystem effect;
    private void OnMouseDown()
    {
        StartCoroutine(Particles());
    }
    IEnumerator Particles()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.clear;
        effect.Play();
        yield return new WaitUntil(() => !effect.IsAlive());
        Destroy(gameObject);
    }
}
