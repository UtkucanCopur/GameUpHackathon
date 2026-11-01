using System;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static event Action<string> OnUpgradeSelected;




    public static void UpgradeSelected(string upgradeType) { OnUpgradeSelected?.Invoke(upgradeType); }
}
