using System;
using UnityEngine;
using TMPro;

public class CharacterBase: MonoBehaviour
{
    
    public HealthSystem healthSystem;
    

    public enum currentState {
        Idle
    }

    [HideInInspector]
    public SpriteRenderer spriteRenderer;
    
    [HideInInspector]
    public Animator animator;

    [HideInInspector]
    public TextMeshPro healthText;

    public Action onAttackAnimationComplete;

    public Weapon equippedWeapon;

    public Armor equippedArmor;

    public int strength;
    public int dexterity;
    public int constitution;

    

    protected virtual void Awake()
    {
        healthSystem = new HealthSystem();
        if(transform.Find("HealthText")){
            healthText = transform.Find("HealthText").GetComponent<TextMeshPro>();
        }
        if(transform.Find("Sprite")){
            spriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
            animator = transform.Find("Sprite").GetComponent<Animator>();
        }

        healthSystem.OnHealthChanged += UpdateHealthText;
        healthSystem.OnHealthChanged += PlayDamageSound;
    }

    
    private void UpdateHealthText(object sender, HealthChangeEventArgs e)
    {
        this.healthText.text = healthSystem.health.ToString();

        if(e.oldValue > e.newValue){
            DamageText.Create(transform.position, e.oldValue - e.newValue);
        }
    }

    private void PlayDamageSound(object sender, HealthChangeEventArgs e)
    {
        if(e.oldValue > e.newValue){
            FindObjectOfType<AudioManager>().Play("attack");
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public int Attack(Action OnComplete)
    {
        DoAttackAnimation();
        int dmg = CalcDamage();
        onAttackAnimationComplete = OnComplete;
        float atkDuration = 1.5f;
        FunctionTimer.Create(atkDuration, OnComplete);
        
        return dmg;
    }

    public void DoAttackAnimation()
    {
        if(animator != null){
            animator.Play("Base Layer.Attack");
        }
    }

    public int CalcDamage()
    {
        int dmg = strength;
        for(int i = 0; i < equippedWeapon.numDice; i++){
            dmg += UnityEngine.Random.Range(1, equippedWeapon.diceSides);
        }
        return dmg;
    }


}
