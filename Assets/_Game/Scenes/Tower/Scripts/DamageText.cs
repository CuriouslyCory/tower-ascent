using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    public static DamageText Create(Vector3 position, int damageAmount) 
    {
        Transform damageTextTransform = Instantiate(GameAssets.i.pfDamageText, position, Quaternion.identity);
        DamageText damageText = damageTextTransform.GetComponent<DamageText>();
        damageText.Setup(damageAmount);

        return damageText;
    }

    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color textColor;

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    public void Setup(int damageAmount)
    {
        textMesh.SetText(damageAmount.ToString());
        textColor = textMesh.color;
        disappearTimer = 1f;
    }

    private void Update() {
        float moveYSpeed = 1f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;
        disappearTimer -= Time.deltaTime;
        if(disappearTimer < 0){
            float disapearSpeed = 3f;
            textColor.a -= disapearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if(textColor.a < 0){
                Destroy(gameObject);
            }
        }
    }
}
