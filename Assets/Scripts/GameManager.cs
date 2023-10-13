using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private LevelControl _levelControl;
    private readonly List<GameObject> SwordsList = new();
    private int _swordIndex;
    private int SwordCount; // Bölümde kaç adet sword oluacaðý

    private readonly List<GameObject> IconList = new();
    private Vector2 IconPosition;

    [SerializeField] private TMP_Text LevelText;
    [SerializeField] Button ThrowButton;

    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] GameObject GameOverPanel;
    [SerializeField] GameObject GameWinPanel;

    [SerializeField] GameObject SceneLoadPanel;
    [SerializeField] Image LoadBarFilled;
    [SerializeField] TMP_Text PercentText;
    [SerializeField] TMP_Text LoadLevelText;


    private void Awake()
    {
        _levelControl = GameObject.FindWithTag("LevelControl").GetComponent<LevelControl>();
        SwordCount = _levelControl.SwordCount; // Bölümde kaç adet kýlýç olacaðýný level kontrol den alýyoruz.
        IconPosition = _levelControl.IconPos;
        LevelText.text = _levelControl.LevelText;

    }
    private void Start()
    {
        if (!PlayerPrefs.HasKey("Score"))
        {
           PlayerPrefs.SetInt("Score", _levelControl.Score);
           ScoreText.text = PlayerPrefs.GetInt("Score").ToString();
        }
        else
        {
            ScoreText.text = PlayerPrefs.GetInt("Score").ToString();
        }


        for (int i = 0; i < SwordCount; i++)
        {
            GameObject newSword = Instantiate(_levelControl.SwordPrefab, transform.position, _levelControl.SwordPrefab.transform.rotation);
            newSword.SetActive(false);
            SwordsList.Add(newSword);

            GameObject newIcon = Instantiate(_levelControl.IconPrefab, IconPosition, _levelControl.IconPrefab.transform.rotation);
            IconPosition.y += _levelControl.IconAltAltaSiralamaDegeri;
            IconList.Add(newIcon);
        }

        SwordsList[0].SetActive(true);


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwordsIconActive();
            _levelControl.ShotControl = true;
        }

       ThrowButton.onClick.AddListener(() =>
       {
           SwordsIconActive();
           _levelControl.ShotControl = true;
       });
    }

    public void ActiveSword()
    {
        if (_swordIndex < SwordCount -1 ) //Þart saðlanana kadar diðer her çarpmada bir arttýrdýk ve o indexe karþýlýk gelen listin içindeki elemaný açtýk.
        {
            _swordIndex++;
            SwordsList[_swordIndex].SetActive(true);
        }
    }

    public void SwordsIconActive()
    {
        IconList[_swordIndex].transform.GetChild(0).gameObject.SetActive(false);
    }

    public void ScoreUp()
    {
        ScoreText.text = _levelControl.Score.ToString();
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        GameOverPanel.SetActive(true);
    }

    public void GameWin()
    {
        Time.timeScale = 0f;
        GameWinPanel.SetActive(true);
    }

    public void NextLevel()
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + _levelControl.Score);
        StartCoroutine(SceneLoad());
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator SceneLoad()
    {
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        PlayerPrefs.SetInt("CurrentLevel", nextLevel);
        SceneLoadPanel.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(nextLevel);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            LoadBarFilled.fillAmount = progress;
            PercentText.text = Mathf.RoundToInt(progress * 100).ToString();
            yield return null;
        }

    }



}
