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

    private PlayerCharacter()
    {
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
