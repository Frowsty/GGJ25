using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Merchant : MonoBehaviour
{
    public static Merchant Instance;

    public GameObject merchantMenu;
    private Button healthUpgradeButton;
    private Button fireRateUpgradeButton;
    private Button damageUpgradeButton;
    private Button pierceUpgradeButton;
    private Button chargeTimeUpgradeButton;
    private Button chargeRateUpgradeButton;

    private TextMeshProUGUI shellCurrencyText;

    private Button closeMerchantButton;

    private Dictionary<string, float> costValues = new();
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        
        healthUpgradeButton = GameObject.Find("UpgradeHealth").GetComponent<Button>();
        fireRateUpgradeButton = GameObject.Find("UpgradeFireRate").GetComponent<Button>();
        damageUpgradeButton = GameObject.Find("UpgradeDamage").GetComponent<Button>();
        pierceUpgradeButton = GameObject.Find("UpgradePierce").GetComponent<Button>();
        chargeTimeUpgradeButton = GameObject.Find("UpgradeChargeTime").GetComponent<Button>();
        chargeRateUpgradeButton = GameObject.Find("UpgradeChargeRate").GetComponent<Button>();
        shellCurrencyText = GameObject.Find("ShellCurrency").GetComponent<TextMeshProUGUI>();
        
        closeMerchantButton = GameObject.Find("CloseMerchant").GetComponent<Button>();
        
        merchantMenu.SetActive(false);
        
        // add base cost values
        costValues.Add("health", 2f);
        costValues.Add("fireRate", 5f);
        costValues.Add("damage", 5f);
        costValues.Add("pierce", 5f);
        costValues.Add("chargeTime", 5f);
        costValues.Add("chargeRate", 5f);
    }

    private void Start()
    {
        // add listener to close button
        closeMerchantButton.onClick.AddListener(delegate
        {
            HideMerchantMenu();
        });
        
        chargeRateUpgradeButton.onClick.AddListener(delegate
        {
            if (PlayerStats.Instance.GetCurrency() >= costValues["chargeRate"])
            {
                PlayerStats.Instance.SetCurrency(PlayerStats.Instance.GetCurrency() - costValues["chargeRate"]);
                PlayerStats.Instance.SetChargeRate(PlayerStats.Instance.GetChargeRate() + 0.5f);
                costValues["chargeRate"] *= 1.5f;
            }
        });
        
        chargeTimeUpgradeButton.onClick.AddListener(delegate
        {
            if (PlayerStats.Instance.GetCurrency() >= costValues["chargeTime"])
            {
                PlayerStats.Instance.SetCurrency(PlayerStats.Instance.GetCurrency() - costValues["chargeTime"]);
                PlayerStats.Instance.SetChargeTime(PlayerStats.Instance.GetChargeTime() + 0.2f);
                costValues["chargeTime"] *= 1.5f;
            }
        });
        
        pierceUpgradeButton.onClick.AddListener(delegate
        {
            if (PlayerStats.Instance.GetCurrency() >= costValues["pierce"])
            {
                PlayerStats.Instance.SetCurrency(PlayerStats.Instance.GetCurrency() - costValues["pierce"]);
                PlayerStats.Instance.SetPierceRate(PlayerStats.Instance.GetPiercingRate() + 0.05f);
                costValues["pierce"] *= 1.5f;
            }
        });
        
        damageUpgradeButton.onClick.AddListener(delegate
        {
            if (PlayerStats.Instance.GetCurrency() >= costValues["damage"])
            {
                PlayerStats.Instance.SetCurrency(PlayerStats.Instance.GetCurrency() - costValues["damage"]);
                PlayerStats.Instance.SetDamage(PlayerStats.Instance.GetDamage() * 1.5f);
                costValues["damage"] *= 1.5f;
            }
        });
        
        fireRateUpgradeButton.onClick.AddListener(delegate
        {
            if (PlayerStats.Instance.GetCurrency() >= costValues["fireRate"])
            {
                PlayerStats.Instance.SetCurrency(PlayerStats.Instance.GetCurrency() - costValues["fireRate"]);
                PlayerStats.Instance.SetChargeFireRate(PlayerStats.Instance.GetChargedFireRate() * 0.85f);
                PlayerStats.Instance.SetFireRate(PlayerStats.Instance.GetFireRate() * 0.85f);
                costValues["fireRate"] *= 1.5f;
            }
        });
        
        healthUpgradeButton.onClick.AddListener(delegate
        {
            if (PlayerStats.Instance.GetCurrency() >= costValues["health"])
            {
                PlayerStats.Instance.SetCurrency(PlayerStats.Instance.GetCurrency() - costValues["health"]);
                PlayerStats.Instance.SetMaxHealth(PlayerStats.Instance.GetMaxHealth() + 5);
                costValues["health"] *= 1.5f;
            }
        });
    }

    public void UpdateMerchantMenu()
    {
        shellCurrencyText.text = "Shells: " + PlayerStats.Instance.GetCurrency().ToString();
    }

    public void ShowMerchantMenu()
    {
        GameManager.Instance.SwitchState<PauseState>();
        merchantMenu.SetActive(true);
    }

    public void HideMerchantMenu()
    {
        GameManager.Instance.SwitchState<PlayingState>();
        merchantMenu.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            collision.gameObject.GetComponent<PlayerInteract>().canInteract = true;
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HideMerchantMenu();
            collision.gameObject.GetComponent<PlayerInteract>().canInteract = false;
        }
    }
}
