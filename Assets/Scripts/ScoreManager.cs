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
    public static float GameSpeed = 2f;
    public static int[] Upgrades = new[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};

    public static float Distance = 0;
    public static List<int> HeatList = new List<int>() { 0, 0, 0, 0, 0 };
    public static int Heat { get => HeatList.Sum(x => x); }
    public static float GoldMulti { get => 1 + (Heat / 10f); }
    public static float DistanceMulti { get => 1 + (Heat / 15f); }
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI DistanceText;
    [SerializeField] TextMeshProUGUI HiScoreText;
    [SerializeField] TextMeshProUGUI HeatText;
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
        GetComponent<UpgradeHandler>().LoadUpgrades();
        DontDestroyOnLoad(gameObject);
    }
    private void FixedUpdate()
    {
        ScoreText.text = $"Schmekels: {Schmekels}";
        DistanceText.text = $"Distance: {System.Math.Round(Distance, 1)}m";
        HiScoreText.text = $"HiScore: {System.Math.Round(__HiDistance, 2)}m";
        HeatText.text = $"Heat: {Heat}";
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
