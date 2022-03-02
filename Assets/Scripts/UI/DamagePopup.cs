using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DamagePopup : MonoBehaviour
{
    public static DamagePopup Create(GameObject prefabPopup,Vector3 position,int damageAmount,bool isGold =false)
    {
        GameObject damagePopupTransform = Instantiate(prefabPopup, position, Quaternion.identity);
        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(damageAmount, isGold);
        return damagePopup;
    }
    TextMeshPro textMesh;
    Color textColor;
    float disappearTimer;
    void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();

    }
    void Setup(int damageAmount, bool isGold)
    {
        
        
        if (isGold)
        {
            textMesh.fontMaterial.SetColor(ShaderUtilities.ID_GlowColor, new Color32(255, 255, 0, 100));
            textColor = Color.yellow;
            textMesh.fontSize = 4;
            textMesh.text = $"+{damageAmount}";
        }
        else
        {
            textMesh.fontMaterial.SetColor(ShaderUtilities.ID_GlowColor, new Color32(255, 0, 0, 100));
            textColor = Color.red;
            textMesh.fontSize = 6;
            textMesh.text = $"-{damageAmount}";
        }
        disappearTimer = 0.5f;
        textMesh.color = textColor;
    }
    void Update()
    {
        float moveYspeed = 1f;
        transform.position += Vector3.up * moveYspeed * Time.deltaTime;
        disappearTimer -= Time.deltaTime;
        if(disappearTimer < 0)
        {
            float disappearSpeed = 3f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if(textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
