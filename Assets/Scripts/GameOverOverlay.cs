using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverOverlay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI DistanceText;

    private void OnEnable()
    {
        if (ScoreManager.Distance > ScoreManager.__HiDistance)
        {
            ScoreManager.__HiDistance = ScoreManager.Distance;
        }
        ScoreManager.SaveScore();
        DistanceText.text = $"Distance: {System.Math.Round(ScoreManager.Distance, 2)}m";
        AudioManager.instance.Stop("music");
        AudioManager.instance.Play("gameover");
        Time.timeScale = 0f;
    }
   
    public void RestartLevel() 
    {
        ScoreManager.Distance = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ContinueLevel()
    {
        FindObjectOfType<Player>().Hp = 1f;
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
    public void GoToShop()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Shop");
    }
}
