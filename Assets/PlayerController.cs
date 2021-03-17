using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private bool isDragging;
    private Vector2 dragOrigin;

    private Rigidbody2D _rb;
    private TextMesh _playerHealthText;

    private bool onCastleFloor;
    private GameObject currentFloor;
    
    private int _health;
    public int Health 
    {
        get => _health;
        set
        {
            // same, just return
            if (_health == value)
                return; 
            
            // not same update, and update text
            _health = value;

            if(_playerHealthText != null){
                _playerHealthText.text = value.ToString();
            }

        }
    }

    void Awake() 
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerHealthText = transform.Find("HealthText").GetComponent<TextMesh>();
        onCastleFloor = false;
    }
    void OnMouseDown() 
    {
        if(Health > 0){
            isDragging = true;
            _rb.isKinematic = true;
            dragOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        }
    }

    void OnMouseUp() 
    {
        isDragging = false;
        _rb.isKinematic = false;
        if(onCastleFloor == true){
            Debug.Log("Ready to fight");
            Enemy enemy = currentFloor.transform.parent.Find("Enemy(Clone)").GetComponent<Enemy>();
            if(enemy.health < Health){
                Health += enemy.health;
                enemy.kill();
            }else{
                Health = 0;
                transform.Rotate(0,0,90);
            }
            Debug.Log("Enemy Health: " + enemy.health);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        Health = 7;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDragging == true){
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }

    }

    void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log("triggered");
        Debug.Log(collider.gameObject.name);
        if(collider.gameObject.name == "Castle - Background"){
            onCastleFloor = true;
            currentFloor = collider.gameObject;
        }
        
    }

    void OnTriggerExit2D(Collider2D collider) {
        Debug.Log("triggered");
        Debug.Log(collider.gameObject);
        if(collider.gameObject.name == "Castle - Background"){
            onCastleFloor = false;
            currentFloor = null;
        }
    }
}

