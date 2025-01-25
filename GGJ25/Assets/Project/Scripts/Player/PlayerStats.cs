using UnityEngine;

public class PlayerStats : StatBase, IPlayerComponent
{
    [SerializeField]
    private float chargeRate;
    [SerializeField]
    private float chargeFireRate;
    [SerializeField]
    private float chargeTime;
    [SerializeField]
    private int fireRate;
    [SerializeField]
    private float piercingRate;
    
    public void UpdateComponent()
    {
        
    }

    public float GetChargeRate() => chargeRate;
    public float GetChargedFireRate() => chargeFireRate;
    public float GetChargeTime() => chargeTime;
    public float GetFireRate() => fireRate;
    public float GetPiercingRate() => piercingRate;
        
    public void SetChargeRate(float newChargeRate) => chargeRate = newChargeRate;
    public void SetChargeFireRate(float newChareFireRate) => chargeFireRate = newChareFireRate;
    public void SetChargeTime(float newChargeTime) => chargeTime = newChargeTime;
    public void SetFireRate(int newFireRate) => fireRate = newFireRate;
    public void SetPierceRate(float newPierce) => piercingRate = newPierce;
}
