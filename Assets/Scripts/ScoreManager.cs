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
    public static int Schmekels = 0;
    
    public static float __HiDistance = 0;
    public static float GameSpeed { get => 2f + HeatHandler.GetHeatValue(HeatType.GameSpeed)*0.1f; }
    public static int[] Upgrades = new[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};

    public static float Distance = 0;
    public static List<int> HeatList = new List<int>() { 0, 0, 0, 0, 0 };
    public static int Heat { get => HeatList.Sum(x => x); }
    public static float GoldMulti { get => 1 + (Heat / 10f); }
    public static float DistanceMulti { get => 1 + (Heat / 15f); }
    
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
        
        ReloadScore();
        FindObjectOfType<UpgradeHandler>().LoadUpgrades();
        DontDestroyOnLoad(gameObject);
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

}
