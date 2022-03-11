using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField] GameObject shopUpgradePrefab;
    [SerializeField] TextMeshProUGUI PlayerShmekels;
    public Upgrade[] Upgrades;
    void Start()
    {
        ScoreManager.ReloadScore();
        PlayerShmekels.text = ScoreManager.Schmekels.ToString();
        for (int i = 0; i < Upgrades.Length; i++)
        {
            Upgrade upgrade = Upgrades[i];
            upgrade.Level = ScoreManager.Upgrades[i];
            upgrade.instance = Instantiate(shopUpgradePrefab, transform);
            upgrade.instance.transform.Find("BuyButton").GetComponent<Button>().onClick.AddListener(() => { UpgradeClick(upgrade, upgrade.instance); });
            UpdateUpgradeGUI(upgrade, upgrade.instance);
        }
    }
    private void UpdateUpgradeGUI(Upgrade upgrade,GameObject shopUpgrade)
    {
        shopUpgrade.transform.Find("Top").Find("Name").GetComponent<TextMeshProUGUI>().SetText(upgrade.name);
        shopUpgrade.transform.Find("Description").GetComponent<TextMeshProUGUI>().SetText(upgrade.description);
        shopUpgrade.transform.Find("BuyButton").Find("Bottom").Find("Cost").GetComponent<TextMeshProUGUI>().SetText(upgrade.Cost.ToString());
        shopUpgrade.transform.Find("LevelTxt").GetComponent<TextMeshProUGUI>().SetText($"LVL: {upgrade.Level}");
    }
    private void UpgradeClick(Upgrade upgrade, GameObject shopUpgrade)
    {
        if (ScoreManager.Schmekels >= (ulong)upgrade.Cost)
        {
            ScoreManager.Schmekels -= (ulong)upgrade.Cost;
            upgrade.Level++;
            UpdateUpgradeGUI(upgrade, shopUpgrade);
            PlayerShmekels.text = ScoreManager.Schmekels.ToString();
            //update Score Manager With the upgrades And Save them in saveData;
        }
        
    }
    public void BackToBattle()
    {
        ScoreManager.Upgrades = ScoreManager.UpgradesToIntArray(Upgrades);
        ScoreManager.SaveScore();
        LevelLoader.Instance.LoadNextLevel("Heat");
    }
    public void BackToMainMenu()
    {
        ScoreManager.Upgrades = ScoreManager.UpgradesToIntArray(Upgrades);
        ScoreManager.SaveScore();
        LevelLoader.Instance.LoadNextLevel("MainMenu");
    }
    public void Refound()
    {
        int amount = 0;
        foreach (Upgrade upgrade in Upgrades)
        {
            amount += upgrade.moneySpent();
            upgrade.Level = 0;
            UpdateUpgradeGUI(upgrade, upgrade.instance);
        }
        ScoreManager.Schmekels += (ulong)(amount * 0.75f);
        PlayerShmekels.text = ScoreManager.Schmekels.ToString();

    }
}
