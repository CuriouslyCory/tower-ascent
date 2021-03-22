using System;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : CharacterBase
{
    public enum EnemyType {
        Enemy1,
        Enemy2,
        Boss1
    }

    public EnemyType enemyType;
    public List<Item> loot;
    public int enemyLevel;

    protected override void Awake() {
        base.Awake();
    }

    public void SetEnemyType(EnemyType type, int level)
    {
        enemyType = type;
        enemyLevel = level;

        spriteRenderer.sprite = GetSprite();
        spriteRenderer.flipX = true;
        healthSystem.maxHealth = level * 5 + UnityEngine.Random.Range(1, 5);
        healthSystem.health = healthSystem.maxHealth;
        dmgPotential = new int[2];
        dmgPotential[0] = 1 * level;
        dmgPotential[1] = 3;
    }

    public void kill()
    {
        
        Destroy(gameObject);
    }

    public Sprite GetSprite()
    {
        switch (enemyType) {
            default:
            case EnemyType.Enemy1:  return EnemyAssets.Instance.enemy1Sprite;
            case EnemyType.Enemy2:  return EnemyAssets.Instance.enemy2Sprite;
            case EnemyType.Boss1:   return EnemyAssets.Instance.boss1Sprite;
        }
    }

}