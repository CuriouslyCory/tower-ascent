using UnityEngine;

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
}
