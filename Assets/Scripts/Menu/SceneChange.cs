using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{   
    public void BattleScene()
    {
        SceneManager.LoadScene("Battle");
    }
    public void MenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ShopScene()
    {
        SceneManager.LoadScene("Shop");
    }
}
