using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private Vector2 dragOrigin;

    private Rigidbody2D _rb;
    private TextMesh _playerHealthText;
    private Animator animator;

    [SerializeField]
    private GameState gameState;

    public PlayerCharacter playerCharacter;

    private enum ControllerStates {
        Idle,
        Dragging,
        Battle,
    }
    private ControllerStates controllerState;

    void Awake() 
    {
        _rb = GetComponent<Rigidbody2D>();
        playerCharacter = gameObject.GetComponent<PlayerCharacter>();
        animator = gameObject.transform.Find("Sprite").GetComponent<Animator>();
        controllerState = ControllerStates.Idle;
    }


    void OnMouseDown() 
    {
        Debug.Log("Mousedown");
        if(gameState.playerHealth > 0 && controllerState == ControllerStates.Idle){
            controllerState = ControllerStates.Dragging;
            _rb.isKinematic = true;
            //animator.enabled = false;
            dragOrigin = playerCharacter.transform.position;
        }
    }

    void OnMouseUp() 
    {
        Debug.Log("MouseUp");
        _rb.isKinematic = false;
        //animator.enabled = true;
        if(playerCharacter.currentFloor != null && controllerState == ControllerStates.Dragging){
            playerCharacter.transform.position = playerCharacter.currentFloor.transform.position + playerCharacter.currentFloor.transform.TransformDirection(new Vector3(6,0));
            controllerState = ControllerStates.Battle;
            Debug.Log("Ready to fight");
            Debug.Log(playerCharacter.currentFloor.transform.GetChild(3));
            //playerCharacter.currentFloor.transform.Find
            NonPlayerCharacter enemy = playerCharacter.currentFloor.transform.GetChild(3).GetComponent<NonPlayerCharacter>();
            BattleSystem battleSystem = BattleSystem.Create(playerCharacter, enemy);
            battleSystem.Start();
        }else{
            transform.position = dragOrigin;
            controllerState = ControllerStates.Idle;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(controllerState == ControllerStates.Dragging){
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }

    }

}