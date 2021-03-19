using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private bool isDragging;
    private Vector2 dragOrigin;

    private Rigidbody2D _rb;
    private TextMesh _playerHealthText;

    [SerializeField]
    private GameState gameState;

    public PlayerCharacter playerCharacter;

    void Awake() 
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerHealthText = transform.Find("HealthText").GetComponent<TextMesh>();
        gameState.OnPlayerHealthChanged += OnPlayerHealthChanged;
        playerCharacter = gameObject.GetComponent<PlayerCharacter>();
    }

    private void OnPlayerHealthChanged(object sender, StateEventArgs e) {
        _playerHealthText.text = e.value.ToString();
    }

    void OnMouseDown() 
    {
        if(gameState.playerHealth > 0){
            isDragging = true;
            _rb.isKinematic = true;
            dragOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        }
    }

    void OnMouseUp() 
    {
        isDragging = false;
        _rb.isKinematic = false;
        if(playerCharacter.currentFloor == true){
            Debug.Log("Ready to fight");
            NonPlayerCharacter enemy = playerCharacter.currentFloor.transform.parent.Find("Enemy(Clone)").GetComponent<NonPlayerCharacter>();
            //BattleSystem battleSystem = new BattleSystem(playerCharacter, enemy);
        }else{
            transform.position = dragOrigin;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(isDragging == true){
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }

    }

}

