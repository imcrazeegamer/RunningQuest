using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeHandler : MonoBehaviour
{
    [SerializeField] FloatingItemGenerator HealItemSpawner;
    [SerializeField] FloatingItemGenerator ShieldSpawner;
    [SerializeField] Player player;
    public void LoadUpgrades()
    {
        for (int i = 0; i < ScoreManager.Upgrades.Length; i++)
        {
            int value = ScoreManager.Upgrades[i];
            switch ((UpgradeType)i)
            {
                case UpgradeType.Jumps:
                    player.maxJumps = value + 1;
                    break;
                case UpgradeType.HpRegen:
                    player.hpRegen = value * 0.01f;
                    break;
                case UpgradeType.HealItem:
                    HealItemSpawner.enabled = value > 0;
                    HealItemSpawner.deltaTimeMod = 0.001f * (value - 1);
                    break;
                case UpgradeType.Shield:
                    ShieldSpawner.enabled = value > 0;
                    ShieldSpawner.deltaTimeMod = 0.001f * (value - 1);
                    break;

            }
        }
        Debug.Log("Upgrades Loaded!");
    }
}
