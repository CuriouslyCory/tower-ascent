using System;

public class HealthSystem 
{
    private int armor;
    public int maxHealth;
    private int _health;
    public int health
    {
        get { return _health; }
        set {
            int oldVal = _health;
            if(value == _health)
                return;
            _health = value;
            OnHealthChanged?.Invoke(this, new HealthChangeEventArgs {oldValue = oldVal, newValue = value});
        }
    }
    public EventHandler<HealthChangeEventArgs> OnHealthChanged;

    public void Damage(int dmgAmt)
    {
        int dmg = dmgAmt - armor;
        // can't do negative damage
        dmg = dmg > 0 ? dmg : 0;

        // can't have negative health
        int newHealth = health - dmg;
        if(newHealth < 0)
            newHealth = 0;
            
        health = newHealth;
    }

    public void Heal(int healAmt)
    {
        if(healAmt + healAmt > maxHealth){
            health = maxHealth; 
        }else{
            health += healAmt;
        }
    }

    public void SetArmor(int armor)
    {
        this.armor = armor;
    }

}

public class HealthChangeEventArgs: EventArgs
{
    public int oldValue;
    public int newValue;
}