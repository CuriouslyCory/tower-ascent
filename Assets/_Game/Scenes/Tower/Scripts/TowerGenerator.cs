using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGenerator : MonoBehaviour
{
    
    [SerializeField] private GameObject towerRoom_1;
    [SerializeField] private Transform grid;

    public List<GameObject> floors;

    private void Awake() {
    }

    private void GenerateFloor(int floor){
        Vector3 position = new Vector3(-10,-2 + (floor * 4));
        GameObject newFloor = Instantiate(towerRoom_1, position, Quaternion.identity, grid);
        SpawnEnemy(NonPlayerCharacter.EnemyType.Enemy1, new Vector3(newFloor.transform.position.x + 4, newFloor.transform.position.y), newFloor.transform);
        floors.Add(newFloor);
    }

    private void SpawnEnemy(NonPlayerCharacter.EnemyType enemyType, Vector3 location, Transform parent)
    {
        Transform enemyObject = Instantiate(EnemyAssets.Instance.pfNonPlayerCharacter, location, Quaternion.identity, parent);
        Debug.Log(enemyObject);
        NonPlayerCharacter enemy = enemyObject.GetComponent<NonPlayerCharacter>();
        Debug.Log(enemy);
        enemy.SetEnemyType(enemyType, 1);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        GenerateFloor(0);
        GenerateFloor(1);
        GenerateFloor(2);
        GenerateFloor(3);
        GenerateFloor(4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
