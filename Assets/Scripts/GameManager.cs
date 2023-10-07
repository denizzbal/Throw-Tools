using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private LevelControl _levelControl;
    private readonly List<GameObject> SwordsList = new();
    private int _swordIndex;
    private int SwordCount; // Bölümde kaç adet sword oluacaðý

    private readonly List<GameObject> IconList = new();
    private Vector2 IconPosition;

    private void Awake()
    {
        _levelControl = GameObject.FindWithTag("LevelControl").GetComponent<LevelControl>();
        SwordCount = _levelControl.SwordCount; // Bölümde kaç adet kýlýç olacaðýný level kontrol den alýyoruz.
        IconPosition = _levelControl.IconPos;

        Debug.Log(Random.Range(0, 136));
    }
    private void Start()
    {
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

    public void GameOver()
    {
        Time.timeScale = 0f;
        Debug.Log("Game Over");
    }

    public void GameWin()
    {
        Time.timeScale = 0f;
        Debug.Log("Game Win");

    }

}
