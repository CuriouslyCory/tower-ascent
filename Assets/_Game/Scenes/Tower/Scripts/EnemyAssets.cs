using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAssets : MonoBehaviour
{
    public static EnemyAssets Instance {get; private set;}

    private void Awake() {
        Instance = this;
    }

    public Transform pfNonPlayerCharacter;

    public Sprite enemy1Sprite;
    public Sprite enemy2Sprite;
    public Sprite boss1Sprite;

}
