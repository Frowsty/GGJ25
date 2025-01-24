using UnityEngine;

public class StatBase : MonoBehaviour
{
    [SerializeField]
    private int Health;
    [SerializeField]
    private int MaxHealth;
    [SerializeField]
    private float MovementSpeed;
    [SerializeField]
    private int Damage;

    public int GetHealth() => Health;
    public int GetMaxHealth() => MaxHealth;
    public float GetMovementSpeed() => MovementSpeed;
    public int GetDamage() => Damage;

    public void SetHealth(int newHealth) => Health = newHealth;
    public void SetMaxHealth(int max) => MaxHealth = max;
    public void SetDamage(int damage) => Damage = damage;
    public void SetMovementSpeed(float movementSpeed) => MovementSpeed = movementSpeed;
    
}
