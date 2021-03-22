using System;
using UnityEngine;

public class BattleSystem
{
    
    public static BattleSystem Create(PlayerCharacter _playerCharacter, NonPlayerCharacter _towerGuard)
    {
        BattleSystem battleSystem = new BattleSystem(_playerCharacter, _towerGuard);
        GameObject gameObject = new GameObject("BattleSystem", typeof(MonoBehaviourHook));
        gameObject.GetComponent<MonoBehaviourHook>().onUpdate = battleSystem.Update;

        return battleSystem;
    }

    public class MonoBehaviourHook : MonoBehaviour {
        public Action onUpdate;
        private void Update() {
            if(onUpdate != null) onUpdate();
        }
    }

    private PlayerCharacter playerCharacter;

    private NonPlayerCharacter towerGuard;

    private enum BattleStates {
        PlayerTurn,
        PlayerAttack,
        EnemyTurn,
        EnemyAttack,
        PlayerDead,
        EnemyDead,
    }

    private BattleStates battleState;

    private BattleSystem(PlayerCharacter _playerCharacter, NonPlayerCharacter _towerGuard)
    {
        this.playerCharacter = _playerCharacter;
        this.towerGuard = _towerGuard;
    }

    public void Start()
    {
        Debug.Log("Battle Start!");
        battleState = BattleStates.PlayerTurn;
        
    }

    public void Update(){
        switch (battleState) {
            case BattleStates.PlayerTurn: 
                battleState = BattleStates.PlayerAttack;
                Attack(playerCharacter, towerGuard);
                break;
            case BattleStates.EnemyTurn:
                battleState = BattleStates.EnemyAttack;
                Attack(towerGuard, playerCharacter);
                break;
            case BattleStates.EnemyDead:
                Debug.Log("Enemy Dead");
                break;
            case BattleStates.PlayerDead:
                Debug.Log("Player Dead");
                break;
            default:
                break;
        }

    }

    private void Attack(CharacterBase attacker, CharacterBase defender)
    {
        int dmg = attacker.Attack(()=>{
            // if both units are still alive, set next state
            if(attacker.healthSystem.health > 0 && defender.healthSystem.health > 0){
                battleState = battleState == BattleStates.PlayerAttack ? BattleStates.EnemyTurn : BattleStates.PlayerTurn;
            }
        });
        defender.healthSystem.Damage(dmg);
        if(defender.healthSystem.health <= 0){
            battleState = battleState == BattleStates.PlayerAttack ? BattleStates.EnemyDead : BattleStates.PlayerDead;
        }
        
    }

    


}
