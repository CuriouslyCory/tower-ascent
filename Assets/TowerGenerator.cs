using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGenerator : MonoBehaviour
{
    
    [SerializeField] private Transform towerRoom_1;
    [SerializeField] private Transform grid;
    [SerializeField] private GameObject enemy1;

    private void Awake() {
        
    }

    private void GenerateFloor(int floor){
        Vector3 position = new Vector3(-10,-2 + (floor * 4));
        Transform room1 = Instantiate(towerRoom_1, position, Quaternion.identity, grid);
        GameObject enemyObject = Instantiate(enemy1, new Vector3(room1.position.x + 4, room1.position.y), Quaternion.identity, room1);
        Enemy enemy = enemyObject.GetComponent<Enemy>();
        enemy.health = Random.Range(5, 12);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        GenerateFloor(0);
        GenerateFloor(1);
        GenerateFloor(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
