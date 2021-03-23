using System;

public class HealthSystem 
{
    public EventHandler OnHealthChanged;
    
    public int maxHealth;
    private int _health;

    private int armor;
    
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

    public HealthSystem(){}

    public void Damage(int dmgAmt)
    {
        int dmg = dmgAmt - armor;
        // don't heal from having too much armor
        health -= dmg > 0 ? dmg : 0;
        if(health < 0)
            health = 0;
    }

    public void Heal(int healAmt)
    {
        health += healAmt;
        if(health > maxHealth)
            health = maxHealth;
    }

    public void SetArmor(int armor)
    {
        this.armor = armor;
    }

}

