using System;

public class HealthSystem 
{
    public EventHandler OnHealthChanged;
    
    public int maxHealth;
    private int _health;
    
    public int health
    {
        get { return _health; }
        set {
            if(value == _health)
                return;
            _health = value;
            OnHealthChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    public HealthSystem(){
        
    }

    public void Damage(int dmgAmt)
    {
        health -= dmgAmt;
    }

    public void Heal(int healAmt)
    {
        health += healAmt;
    }

}
