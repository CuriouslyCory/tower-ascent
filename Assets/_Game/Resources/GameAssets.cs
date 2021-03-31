using UnityEngine;
using System.Collections.Generic;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets i {
        get {
            if(_i == null){
                Debug.Log("_i is null, instantiate");
                _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            } 
            Debug.Log("GameAssets should be instantiated");
            Debug.Log(_i);
            return _i;
        }
    }

    public Transform pfDamageText;
    public Transform pfErrorTMessage;

    public Transform pfEnemy1;
    public Transform pfEnemy2;
    public Transform pfBoss1;

    public GameState gameState;
}
