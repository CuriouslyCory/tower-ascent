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
    public int gold;
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

    public void SetEnemyType(EnemyType type, int level)
    {
        enemyType = type;
        enemyLevel = level;

        spriteRenderer.sprite = GetSprite();
        spriteRenderer.flipX = true;
        healthSystem.maxHealth = level * 5 + (UnityEngine.Random.Range(1 , 5 * level) / 2);
        healthSystem.health = healthSystem.maxHealth;
        dmgPotential = new int[2];
        dmgPotential[0] = 1 * level;
        dmgPotential[1] = 3;
        gold = UnityEngine.Random.Range(1, 5 * level);
        AddRandomItems(level);
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

}