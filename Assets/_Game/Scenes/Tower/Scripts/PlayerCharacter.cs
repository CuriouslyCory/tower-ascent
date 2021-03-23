using System;
using UnityEngine;
public class PlayerCharacter : CharacterBase
{
    [SerializeField]
    private GameState gameState;
    public Inventory inventory;

    public bool onCastleFloor;
    public GameObject currentFloor;

    public EventHandler<PlayerStateEventArgs> OnPlayerStateChanged;


    public enum PlayerStates {
        Idle,
        Dragging,
        Fighting,
        Dead,
    }

    private PlayerStates _playerState;
    public PlayerStates playerState{
        get { return _playerState; }
        set {
            if(value == _playerState)
                return;
            
            _playerState = value;
            OnPlayerStateChanged?.Invoke(this, new PlayerStateEventArgs {value = value});
        }
    }

    protected override void Awake() {
        base.Awake();
        spriteRenderer = GetComponent<SpriteRenderer>();
        healthSystem.maxHealth = gameState.playerMaxHealth;
        healthSystem.health = healthSystem.maxHealth;

        healthSystem.OnHealthChanged += OnHealthChanged;
    }

    void OnTriggerEnter2D(Collider2D collider) {
        Debug.Log("enter triggered");
        Debug.Log(collider.gameObject.name);
        if(collider.gameObject.name == "pfCastleRoom(Clone)"){
            onCastleFloor = true;
            currentFloor = collider.gameObject;
        }
        
    }

    void OnTriggerExit2D(Collider2D collider) {
        Debug.Log("exit triggered");
        Debug.Log(collider.gameObject);
        if(collider.gameObject.name == "pfCastleRoom(Clone)"){
            onCastleFloor = false;
            currentFloor = null;
        }
    }

    private void OnHealthChanged(object sender, EventArgs e)
    {
        if(healthSystem.health == 0)
        {
            if(animator != null){
                animator.Play("Base Layer.Death");
            }
            playerState = PlayerStates.Dead;
        }
    }
}
