using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    [SerializeField] GameObject SceneLoadPanel;
    [SerializeField] TMP_Text PercentText;
    [SerializeField] Image LoadBarFilled;
    int _currentLevel;
    void Start()
    {
        CurrentLevelPrefs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        StartCoroutine(SceneLoad());
    }

    public void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        CurrentLevelPrefs();
    }

    private void CurrentLevelPrefs()
    {
        if (!PlayerPrefs.HasKey("CurrentLevel"))
        {
            PlayerPrefs.SetInt("CurrentLevel", 1);
            _currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        }
        else
        {
            _currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        }
    }

    IEnumerator SceneLoad()
    {
        SceneLoadPanel.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(_currentLevel);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            LoadBarFilled.fillAmount = progress;
            PercentText.text = Mathf.RoundToInt(progress * 100).ToString();
            yield return null;
        }
    }

    public void GithubLink()
    {
        Application.OpenURL("https://github.com/denizzbal");

    }
}
