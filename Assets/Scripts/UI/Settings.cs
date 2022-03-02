using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Settings : MonoBehaviour
{
    [SerializeField] GameObject prefabSetting;
    GameObject Music, SFX;
    public static bool isMusic = true, isSFX = true;
    void Start()
    {
        Music = Instantiate(prefabSetting, transform);
        Music.GetComponentInChildren<Toggle>().isOn = isMusic;
        Music.GetComponentInChildren<TextMeshProUGUI>().text = "Music";

        SFX = Instantiate(prefabSetting, transform);
        SFX.GetComponentInChildren<Toggle>().isOn = isSFX;
        SFX.GetComponentInChildren<TextMeshProUGUI>().text = "SFX";
    }

    public void ReturnToMenu()
    {
        isMusic = Music.GetComponentInChildren<Toggle>().isOn;
        isSFX = SFX.GetComponentInChildren<Toggle>().isOn;
        SceneManager.LoadScene("MainMenu");
    }
    public void ResetGameSave()
    {
        SaveSystem.SaveGame(new SaveData());
    }
}
