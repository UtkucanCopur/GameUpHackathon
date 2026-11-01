using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private Image expBar;
    [SerializeField] GameObject levelUpPanel;
    [SerializeField] Upgrades[] upgrades;
    [SerializeField] Image[] upgradesImages;
    [SerializeField] TextMeshProUGUI[] upgradesInfos;
    [SerializeField] string[] buttonsUpgrades;
    [SerializeField] private string selectedUpgrade;



    [Header("Stats")]
    public float currentHealth;
    public float maxHealth;
    public float currentExp;
    public float maxExp;
    public float additionalExp;


     



    private void OnEnable()
    {
        PlayerDeadZone.OnProjectileHit += TakeDamage;
        PlayerMovement.OnProjectileSave += GainExp;
        PlayerUpgrades.OnIncreaseExpGain += IncreaseExpGain;
        PlayerUpgrades.OnIncreaseMaxHealth += IncreaseMaxHealth;
    }

    private void OnDisable()
    {
        PlayerDeadZone.OnProjectileHit -= TakeDamage;
        PlayerMovement.OnProjectileSave -= GainExp;
        PlayerUpgrades.OnIncreaseExpGain -= IncreaseExpGain;
        PlayerUpgrades.OnIncreaseMaxHealth -= IncreaseMaxHealth;
    }
    private void Start()
    {
        StartActions();        
    }

    private void IncreaseMaxHealth(int amount)
    {
        maxHealth += maxHealth + amount;
    }
    private void IncreaseExpGain(int amount)
    {
        additionalExp += amount;
    }
    private void StartActions()
    {
        currentHealth = 100;
        UpdateHealthBar();
        currentExp = 0;
        UpdateExpBar();
    }

    private void LevelUp()
    {
        currentExp = 0;
        UpdateExpBar();
        Time.timeScale = 0f;
        levelUpPanel.SetActive(true);


        AssignUpgradesRandomly();
    }

    private void AssignUpgradesRandomly()
    {
        List<int> usedRandoms = new List<int>();

        for (int i = 0; i < buttonsUpgrades.Length && usedRandoms.Count < upgrades.Length; i++)
        {
            int random;

            do
            {
                random = Random.Range(0, upgrades.Length);
            }
            while (usedRandoms.Contains(random));

            usedRandoms.Add(random);

            upgradesImages[i].sprite = upgrades[random].image;
            upgradesInfos[i].text = upgrades[random].info;
            buttonsUpgrades[i] = upgrades[random].type;
        }
    }

    public void Upgrade1Button()
    {
        levelUpPanel.SetActive(false);
        Time.timeScale = 1f;
        selectedUpgrade = buttonsUpgrades[0];
        UpgradeManager.UpgradeSelected(selectedUpgrade);
    }

    public void Upgrade2Button()
    {
        levelUpPanel.SetActive(false);
        Time.timeScale = 1f;
        selectedUpgrade = buttonsUpgrades[1];
        UpgradeManager.UpgradeSelected(selectedUpgrade);
    }
    public void Upgrade3Button()
    {
        levelUpPanel.SetActive(false);
        Time.timeScale = 1f;
        selectedUpgrade = buttonsUpgrades[2];
        UpgradeManager.UpgradeSelected(selectedUpgrade);
    }
    private void GainExp(int amount)
    {
        currentExp += amount + additionalExp;
        currentExp = Mathf.Clamp(currentExp, 0, maxExp);
        UpdateExpBar();
        if (currentExp >= maxExp)
            LevelUp();
    }

    private void UpdateExpBar()
    {
        expBar.fillAmount = currentExp / maxExp;
    }

    private void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }


    private void UpdateHealthBar()
    {
        healthBar.fillAmount = currentHealth / maxHealth;
    }

    
}
