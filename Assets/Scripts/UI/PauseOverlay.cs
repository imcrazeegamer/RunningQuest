using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseOverlay : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 0f;
        AudioManager.instance.Pause("music");
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
        AudioManager.instance.Resume("music");
    }
    public void GoToShop()
    {
        ChangeScene();
        SceneManager.LoadScene("Shop");
    }
    public void GoToMainMenu()
    {
        ChangeScene();
        SceneManager.LoadScene("MainMenu");
    }
    void ChangeScene()
    {
        AudioManager.instance.Resume("music");
        AudioManager.instance.Stop("music");
        Save();
    }
}
