using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private static LevelLoader _instance;
    public static LevelLoader Instance { get => _instance; }
    [SerializeField] float transitionTime = 0.5f;
    Animator animator;
    private void Awake()
    {
        _instance = this;
        animator = GetComponentInChildren<Animator>();
    }
    private void Start()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        AudioManager.instance.Play($"music{sceneName}");
    }
    public void LoadNextLevel(string name)
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadLevel(name));
    }
    IEnumerator LoadLevel(string name)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        AudioManager.instance.StopAll();
        SceneManager.LoadScene(name);
    }
}
