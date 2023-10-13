using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    //Bu de�i�keni prefab da �a��rd���m�zda her zaman s�f�rland��� i�in burada kontrol ettik ve swordsControl den her �arp��mada artt�rd�k.
    private int _swordNum = 0;
    public int SwordNum { get =>_swordNum; set => _swordNum = value; }

    [Header("Level Name")]
    [SerializeField] private string _levelText;
    public string LevelText { get => _levelText; set => _levelText = value; }

    //B�l�mde ka� adet k�l�� f�rlat�laca��
    [Header("Toplam K�l�� Say�s�")]
    [SerializeField] private int _swordCount;
    public int SwordCount { get => _swordCount; set => _swordCount = value; }

    [Header("K�l�� F�rlatma H�z�")]
    [SerializeField] private float _moveSpeed;
    public float MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }

    [Header("Sword Prefab")]
    [SerializeField] private GameObject _sword;
    public GameObject SwordPrefab { get => _sword; set => _sword = value; }

    [Header("�con Prefab")]
    [SerializeField] private GameObject _icon;
    public GameObject IconPrefab { get => _icon; set => _icon = value; }

    [Header("�lk iconun pozisyonu")]
    [SerializeField] private Vector2 _iconPos;
    public Vector2 IconPos { get => _iconPos; set => _iconPos = value; }

    [Header("�conlar�n aras�ndaki mesafe")]
    [SerializeField] private float _iconAltAltaSiralamaDegeri;
    public float IconAltAltaSiralamaDegeri { get => _iconAltAltaSiralamaDegeri; set => _iconAltAltaSiralamaDegeri = value; }

    [SerializeField] private GameObject _platform;
    public GameObject Platform { get => _platform; set => _platform = value; }

    [Header("Platform D�n�� H�z�")]
    [SerializeField] private float _rotationSpeed;
    public float RotationSpeed { get => _rotationSpeed; set => _rotationSpeed = value; }

    private bool _shotControl;
    public bool ShotControl { get => _shotControl; set => _shotControl = value; }

    private int _score = 0;
    public int Score { get => _score; set => _score = value; }




}
