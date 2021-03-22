using System;
using UnityEngine;

public class CharacterBase: MonoBehaviour
{
    
    public HealthSystem healthSystem;
    

    public enum currentState {
        Idle
    }
    public int[] dmgPotential;


    public SpriteRenderer spriteRenderer;
    public Animator animator;

    public TextMesh healthText;

    public Action onAttackAnimationComplete;

    protected virtual void Awake()
    {
        healthSystem = new HealthSystem();
        if(transform.Find("HealthText")){
            healthText = transform.Find("HealthText").GetComponent<TextMesh>();
        }
        if(transform.Find("Sprite")){
            spriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
            animator = transform.Find("Sprite").GetComponent<Animator>();
        }

        healthSystem.OnHealthChanged += UpdateHealthText;
    }

    
    private void UpdateHealthText(object sender, EventArgs e)
    {
        Debug.Log("Updating health text");
        this.healthText.text = healthSystem.health.ToString();
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
        float atkDuration = 2;
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
