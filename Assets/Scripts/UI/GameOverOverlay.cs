using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverOverlay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI DistanceText;
    [SerializeField] List<TextMeshProUGUI> HeatText;

    private void OnEnable()
    {
        if (ScoreManager.Distance > ScoreManager.__HiDistance)
        {
            ScoreManager.__HiDistance = ScoreManager.Distance;
        }
        ScoreManager.SaveScore();
        DistanceText.text = $"Distance: {System.Math.Round(ScoreManager.Distance, 2)}m \r\n High Score: {System.Math.Round(ScoreManager.__HiDistance, 2)}m";
        for (int i = 0; i < ScoreManager.HeatList.Count; i++)
        {
            HeatText[i].text = ScoreManager.HeatList[i].ToString();
        }
        AudioManager.instance.Stop("music");
        AudioManager.instance.Play("gameover");
        Time.timeScale = 0f;
    }
   
    public void RestartLevel() 
    {
        ScoreManager.Distance = 0;
        Time.timeScale = 1f;
        LevelLoader.Instance.LoadNextLevel(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ContinueLevel()
    {
        FindObjectOfType<Player>().Hp = 1f;
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
    public void GoToShop()
    {
        ScoreManager.Distance = 0;
        ScoreManager.SaveScore();
        LevelLoader.Instance.LoadNextLevel("Shop");
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName("Shop"));
    }
}
