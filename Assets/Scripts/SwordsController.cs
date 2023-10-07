using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordsController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private bool _shotControl;
    private GameManager _gameManager;
    private LevelControl _levelControl;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        _levelControl = GameObject.FindWithTag("LevelControl").GetComponent<LevelControl>();

        Time.timeScale = 1f;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _gameManager.SwordsIconActive();
            _shotControl = true;
        }
    }

    private void FixedUpdate()
    {
        ThrowSwords(); 
    }

    void ThrowSwords()
    {
        if (_shotControl)
        {
            _rigidbody.AddForce(_levelControl.MoveSpeed * Time.fixedDeltaTime * Vector2.up,ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            _gameManager.ActiveSword();
            _shotControl = false;
            _rigidbody.isKinematic = true;
            transform.SetParent(collision.transform);
            _levelControl.SwordNum++; // Bölümde swordsCount kadar kýlýç atýldýysa iþlem yapýlacak onun için her bir atýþta 1 arttýyoruz.
            if (_levelControl.SwordCount <= _levelControl.SwordNum)
            {
                _gameManager.GameWin();

            }


        }

        if (collision.gameObject.CompareTag("Swords"))
        {
            _gameManager.GameOver();
        }
    }
}
