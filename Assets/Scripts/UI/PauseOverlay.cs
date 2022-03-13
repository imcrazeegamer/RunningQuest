using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseOverlay : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 0f;
        AudioManager.instance.Pause("musicBattle");
        AudioManager.instance.Play("pauseStart");
    }
    private void Update()
    {
        if (gameObject.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            ContinueLevel();
        }
    }
    void Save()
    {
        ScoreManager.Distance = 0;
        Time.timeScale = 1f;
        ScoreManager.SaveScore();
    }
    public void ContinueLevel()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
        AudioManager.instance.Play("pauseEnd");
        AudioManager.instance.Resume("musicBattle");
    }
    public void GoToShop()
    {
        ChangeScene();
        LevelLoader.Instance.LoadNextLevel("Shop");
    }
    public void GoToMainMenu()
    {
        ChangeScene();
        LevelLoader.Instance.LoadNextLevel("MainMenu");
    }
    void ChangeScene()
    {
        AudioManager.instance.Resume("musicBattle");
        AudioManager.instance.Stop("musicBattle");
        Save();
    }
}
