using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private Image expBar;
    [Header("Stats")]
    public float currentHealth;
    public float maxHealth;
    public float currentExp;
    public float maxExp;


    private void OnEnable()
    {
        PlayerDeadZone.OnProjectileHit += TakeDamage;
        PlayerMovement.OnProjectileSave += GainExp;
        
    }

    private void OnDisable()
    {
        PlayerDeadZone.OnProjectileHit -= TakeDamage;
        PlayerMovement.OnProjectileSave -= GainExp;
    }
    private void Start()
    {
        StartActions();        
    }

    private void StartActions()
    {
        currentHealth = 100;
        UpdateHealthBar();
        currentExp = 0;
        UpdateExpBar();
    }

    private void GainExp(int amount)
    {
        currentExp += amount;
        currentExp = Mathf.Clamp(currentExp, 0, maxExp);
        UpdateExpBar();
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
