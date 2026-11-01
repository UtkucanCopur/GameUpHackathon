using System;
using System.Collections;
using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{

    [SerializeField] private GameObject shield360;
    [SerializeField] private GameObject immortalityShield;
    public static event Action<int> OnIncreaseExpGain;
    public static event Action<int> OnIncreaseMaxHealth;


    private void OnEnable()
    {
        UpgradeManager.OnUpgradeSelected += HandleUpgrades;
    }

    private void OnDisable()
    {
        UpgradeManager.OnUpgradeSelected -= HandleUpgrades;
    }

    private void HandleUpgrades(string selectedUpgrade)
    {
        switch (selectedUpgrade)
        {
            case "Scale":
                HandleScaleUpgrades();
                break;
            case "360Shield":
                Handle360Shield();
                break;
            case "ExpGain":
                HandleExpGain();
                break;
            case "IncreaseHealth":
                HandleIncreaseHealth();
                break;
            case "Immortality":
                HandleImmortality();
                break;
            default:
                break;
        }
    }

    private void HandleImmortality()
    {
        StopAllCoroutines();
        StartCoroutine(ActivateImmortality());
    }

    IEnumerator ActivateImmortality()
    {
        immortalityShield.SetActive(true);

        yield return new WaitForSeconds(3f);

        immortalityShield.SetActive(false);
    }

    private void HandleIncreaseHealth()
    {
        OnIncreaseMaxHealth?.Invoke(25);
    }

    private void HandleExpGain()
    {
        OnIncreaseExpGain?.Invoke(10);
    }

    private void HandleScaleUpgrades()
    {
        transform.localScale = new Vector3(transform.localScale.x+.25f, transform.localScale.y, transform.localScale.z);
    }

    private void Handle360Shield()
    {
        StopAllCoroutines();
        StartCoroutine(Activate360Shield());
    }

    IEnumerator Activate360Shield()
    {
        shield360.SetActive(true);

        yield return new WaitForSeconds(3f);

        shield360.SetActive(false);
    }


}
