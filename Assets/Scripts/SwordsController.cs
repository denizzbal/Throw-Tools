using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordsController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private GameManager _gameManager;
    private LevelControl _levelControl;

    int _scoreShootPoint;
    int _currentLevelPoint; // �u an ki puan

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        _levelControl = GameObject.FindWithTag("LevelControl").GetComponent<LevelControl>();

        Time.timeScale = 1f;
    }
    void Update()
    {
        
    }



    private void FixedUpdate()
    {
        ThrowSwords(); 
    }

    void ThrowSwords()
    {
        if (_levelControl.ShotControl)
        {
            _rigidbody.AddForce(_levelControl.MoveSpeed * Time.fixedDeltaTime * Vector2.up,ForceMode2D.Impulse);
        }
    }

    //GameOver Olunca puan devam ediyor.
    //Oyuncu GameWin paneli geldi�inde oyunu kapat�p a�arsa o levelden tekrar kazand��� puanla ba�l�yor bu sorun ��z.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Swords"))
        {
            _gameManager.GameOver();
        }

        if (collision.gameObject.CompareTag("Platform"))
        {
            _gameManager.ActiveSword();
            _levelControl.ShotControl = false;
            _rigidbody.isKinematic = true;
            transform.SetParent(collision.transform);

            _levelControl.Score += 10;
            _gameManager.ScoreUp();
            
            _levelControl.SwordNum++; // B�l�mde swordsCount kadar k�l�� at�ld�ysa i�lem yap�lacak onun i�in her bir at��ta 1 artt�yoruz.
            if (_levelControl.SwordCount <= _levelControl.SwordNum)
            {

                StartCoroutine(GameWinStop());
            }


        }

        
    }

    IEnumerator GameWinStop()
    {
        yield return new WaitForSeconds(0.6f);
        _gameManager.GameWin();
    }
}
