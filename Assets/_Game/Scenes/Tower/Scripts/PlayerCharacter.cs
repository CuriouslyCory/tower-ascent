using System;
using UnityEngine;
public class PlayerCharacter : CharacterBase
{
    [SerializeField]
    private GameState gameState;
    public Inventory inventory;

    public bool onCastleFloor;
    public GameObject currentFloor;


    private enum PlayerState {
        Idle,
        Dragging,
        Fighting,
        Dead,
    }

    protected override void Awake() {
        base.Awake();
        spriteRenderer = GetComponent<SpriteRenderer>();
        healthSystem.maxHealth = 11;
        healthSystem.health = 11;
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
}
