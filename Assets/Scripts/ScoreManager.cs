using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager _instance;
    public static ScoreManager Instance {get => _instance;}
    public static SaveData __SaveData;
    public static ulong Schmekels = 0;
    
    public static float __HiDistance = 0;
    public static float GameSpeed { get => 2f + HeatHandler.GetHeatValue(HeatType.GameSpeed)*0.5f; }
    public static int[] Upgrades = new[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};

    public static float Distance = 0;
    public static List<int> HeatList = new List<int>() { 0, 0, 0, 0, 0 };
    public static int Heat = 0;
    public static float GoldMulti { get => 1 + (Heat / 10f); }
    public static float DistanceMulti { get => 1 + (Heat / 20f); }
    public static int GetCurrentHeat { get => HeatList.Sum(x => x); }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        Heat = HeatList.Sum(x => x);
        ReloadScore();
        FindObjectOfType<UpgradeHandler>().LoadUpgrades();
        FindObjectOfType<BackgroundHandler>().SwitchBackground(Heat);
        DontDestroyOnLoad(gameObject);
        //Schmekels = ulong.MaxValue - 1000000;
    }
    public static int[] UpgradesToIntArray(Upgrade[] upgrades)
    {
        int[] arr = new int[upgrades.Length];
        for (int i = 0; i < upgrades.Length; i++)
        {
            arr[i] = upgrades[i].Level;
        }
        return arr;
    }
    public static void ReloadScore()
    {
        __SaveData = SaveSystem.LoadGame();
        Schmekels = __SaveData.schmekels;
        __HiDistance = __SaveData.highDistance;
        Upgrades = __SaveData.upgrades;
    }
    public static void SaveScore()
    {        
        SaveSystem.SaveGame(new SaveData(__HiDistance, Schmekels, Upgrades));
    }

    public static void AddSchmekels(int amount)
    {
        Schmekels += (ulong)SchmekelCalc(amount);
    }
    public static void AddDistance(float amount)
    {
        Distance += DistanceCalc(amount);
    }
    public static int SchmekelCalc(int amount) { return (int)(amount * GoldMulti); }
    public static float DistanceCalc(float amount) { return amount * DistanceMulti; }

    public static void SchmekelsReward()
    {
        Schmekels = (ulong)(1.01f * Schmekels);
        AudioManager.instance.Play("coin");
        FindObjectOfType<StatPanel>().UpdateSchmekels(Schmekels);
    }

}
