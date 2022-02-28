using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public static SaveData __SaveData;
    public static int Schmekels = 0;
    public static float Distance = 0;
    public static float __HiDistance = 0;
    public static float GameSpeed = 2;
    public static int[] Upgrades = new[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI DistanceText;
    [SerializeField] TextMeshProUGUI HiScoreText;
    private void Awake()
    {
        ReloadScore();
        GetComponent<UpgradeHandler>().LoadUpgrades();
        DontDestroyOnLoad(gameObject);
    }
    private void FixedUpdate()
    {
        ScoreText.text = $"Schmekels: {Schmekels}";
        DistanceText.text = $"Distance: {System.Math.Round(Distance, 1)}m";
        HiScoreText.text = $"HiScore: {System.Math.Round(__HiDistance, 2)}m";
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
