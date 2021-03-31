using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ErrorMessage : MonoBehaviour
{
    public static ErrorMessage Create(Vector3 position, string message) 
    {
        Transform errorMessageTransform = Instantiate(GameAssets.i.pfErrorTMessage, FindObjectOfType<Canvas>().transform);
        ErrorMessage errorMessage = errorMessageTransform.GetComponent<ErrorMessage>();
        errorMessage.Setup(message);

        return errorMessage;
    }

    private TextMeshProUGUI textMesh;
    private float disappearTimer;
    private Color textColor;

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshProUGUI>();
    }

    public void Setup(string message)
    {
        textMesh.SetText(message);
        textColor = textMesh.color;
        disappearTimer = 2f;
    }

    private void Update() {
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
