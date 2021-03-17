using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    TextMesh _healthText;
    private GameObject prefab;

    public GameObject enemyPrefab;


    void Awake()
    {
        _healthText = transform.Find("HealthText").GetComponent<TextMesh>();
    }
    void Start()
    {
        prefab = Instantiate(enemyPrefab, gameObject.transform.position, Quaternion.identity, transform);
        _healthText.text = health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // if(_healthText.text != health.ToString()){
        //     _healthText.text = health.ToString();
        // }
    }

    public void kill()
    {
        Destroy(prefab);
        Destroy(_healthText);
    }
}
