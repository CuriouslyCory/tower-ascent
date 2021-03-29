using System;
using UnityEngine;
using TMPro;

public class CharacterBase: MonoBehaviour
{
    
    public HealthSystem healthSystem;
    

    public enum currentState {
        Idle
    }
    public int[] dmgPotential;


    public SpriteRenderer spriteRenderer;
    public Animator animator;

    public TextMeshPro healthText;

    public Action onAttackAnimationComplete;

    [SerializeField]

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
    }

    
    private void UpdateHealthText(object sender, HealthChangeEventArgs e)
    {
        Debug.Log("Updating health text");
        this.healthText.text = healthSystem.health.ToString();

        if(e.oldValue > e.newValue){
            DamageText.Create(transform.position, e.oldValue - e.newValue);
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
        int dmg = 0;
        for(int i = 0; i < dmgPotential[0]; i++){
            dmg += UnityEngine.Random.Range(1, dmgPotential[1]);
        }
        return dmg;
    }


}
