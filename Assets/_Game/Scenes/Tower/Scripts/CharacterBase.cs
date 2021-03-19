using UnityEngine;

public class CharacterBase: MonoBehaviour
{
    public int maxHealth;
    public int health;
    public enum currentState {
        Idle
    }
    public int[] dmgPotential;


    public Texture2D spriteSheet;


}
