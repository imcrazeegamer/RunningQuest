using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Settings : MonoBehaviour
{
    [SerializeField] GameObject prefabSetting;
    [SerializeField] GameObject masterVolume;
    GameObject Music, SFX;
    public static bool isMusic = true, isSFX = true;
    public static float volume = 1f;
    void Start()
    {
        Music = Instantiate(prefabSetting, transform);
        Music.GetComponentInChildren<Toggle>().isOn = isMusic;
        Music.GetComponentInChildren<TextMeshProUGUI>().text = "Music";

        SFX = Instantiate(prefabSetting, transform);
        SFX.GetComponentInChildren<Toggle>().isOn = isSFX;
        SFX.GetComponentInChildren<TextMeshProUGUI>().text = "SFX";

        UpdateText();
    }
    public void ChangeVolume(float delta)
    {
        float min = 0;
        float max = 1;
        if(volume + delta < min)
        {
            volume = min;
        }
        else if(volume + delta > max)
        {
            volume = max;
        }
        else
        {
            volume += delta;
            AudioManager.instance.Play("btnUI");
        }
        UpdateText();
    }
    public void UpdateText()
    {
        masterVolume.GetComponent<TextMeshProUGUI>().text = $"{System.Math.Round(volume,1)*100}%";
    }
    public void ReturnToMenu()
    {
        isMusic = Music.GetComponentInChildren<Toggle>().isOn;
        isSFX = SFX.GetComponentInChildren<Toggle>().isOn;
        AudioManager.instance.UpdateMasterVolume();
        LevelLoader.Instance.LoadNextLevel("MainMenu");
    }
    public void ResetGameSave()
    {
        SaveSystem.SaveGame(new SaveData());
    }
}
