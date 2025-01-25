using UnityEngine;

public class PlayerStats : StatBase, IPlayerComponent
{
    public static PlayerStats Instance;
    [SerializeField]
    private float chargeRate;
    [SerializeField]
    private float chargeFireRate;
    [SerializeField]
    private float chargeTime;
    [SerializeField]
    private float fireRate;
    [SerializeField]
    private float piercingRate;
    [SerializeField]
    private float currency;

    public Room activeRoom;
    
    public void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    
    public void UpdateComponent()
    {
        if (GetHealth() <= 0)
            GameManager.Instance.SwitchState<PauseState>();
        // switch to death screen
    }

    public float GetChargeRate() => chargeRate;
    public float GetChargedFireRate() => chargeFireRate;
    public float GetChargeTime() => chargeTime;
    public float GetFireRate() => fireRate;
    public float GetPiercingRate() => piercingRate;
    public float GetCurrency() => currency;
        
    public void SetChargeRate(float newChargeRate) => chargeRate = newChargeRate;
    public void SetChargeFireRate(float newChargeFireRate) => chargeFireRate = newChargeFireRate;
    public void SetChargeTime(float newChargeTime) => chargeTime = newChargeTime;
    public void SetFireRate(float newFireRate) => fireRate = newFireRate;
    public void SetPierceRate(float newPierce) => piercingRate = newPierce;
    public void SetCurrency(float newCurrency) => currency = newCurrency;
}
