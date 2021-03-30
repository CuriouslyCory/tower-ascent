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
    
    [HideInInspector]
    public List<Item> loot;
    
    [HideInInspector]
    public int gold;
    
    [HideInInspector]
    public int enemyLevel;

    private enum PlayerStates {
        Idle,
        Fighting,
        Dead,
    }
    private PlayerStates playerState;

    protected override void Awake() {
        base.Awake();
        
        healthSystem.OnHealthChanged += OnHealthChanged;
    }

    public void SetEnemyLevel(int level)
    {
        enemyLevel = level;
        spriteRenderer.flipX = true;
        healthSystem.maxHealth = (level * 5) + (UnityEngine.Random.Range(1 , 5 * constitution) / 2);
        healthSystem.health = healthSystem.maxHealth;
        gold = UnityEngine.Random.Range(1, 5 * level);
        AddRandomItems(level);
    }

    public void kill()
    {
        
        Destroy(gameObject);
    }


    private void AddRandomItems(int level){

    }

    private void OnHealthChanged(object sender, EventArgs e)
    {
        if(healthSystem.health <= 0)
        {
            if(animator != null){
                animator.Play("Base Layer.Death");
            }
            playerState = PlayerStates.Dead;
        }
    }

    public static Transform GetPF(EnemyType enemyType)
    {
        switch (enemyType) {
            default:
            case EnemyType.Enemy1:  return GameAssets.i.pfEnemy1;
            case EnemyType.Enemy2:  return GameAssets.i.pfEnemy2;
            case EnemyType.Boss1:   return GameAssets.i.pfBoss1;
        }
    }

}