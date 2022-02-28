using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    [SerializeField] Vector2 parrlaxEffectMulti = new Vector2(0.5f,0f);
    Vector2 offset;
    Material material;
    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    void LateUpdate()
    {
        offset = parrlaxEffectMulti * Time.deltaTime * ScoreManager.GameSpeed * 0.28f;
        material.mainTextureOffset += offset;
    }
}
