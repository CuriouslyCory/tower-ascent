using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    
    private bool isDragging;
    public Rigidbody2D _rb;


    void Awake() 
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void OnMouseDown() 
    {
        isDragging = true;
        _rb.isKinematic = true;

    }

    void OnMouseUp() 
    {
        isDragging = false;
        _rb.isKinematic = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isDragging == true){
            Vector2 mousepPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousepPosition);
        }
    }
}
