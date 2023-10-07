using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private LevelControl _levelControl;
    private readonly List<GameObject> SwordsList = new();
    private int _swordIndex;
    private int SwordCount; // B�l�mde ka� adet sword oluaca��

    private readonly List<GameObject> IconList = new();
    private Vector2 IconPosition;

    private void Awake()
    {
        _levelControl = GameObject.FindWithTag("LevelControl").GetComponent<LevelControl>();
        SwordCount = _levelControl.SwordCount; // B�l�mde ka� adet k�l�� olaca��n� level kontrol den al�yoruz.
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
        if (_swordIndex < SwordCount -1 ) //�art sa�lanana kadar di�er her �arpmada bir artt�rd�k ve o indexe kar��l�k gelen listin i�indeki eleman� a�t�k.
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
