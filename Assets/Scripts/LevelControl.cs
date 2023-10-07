using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    //Bu deðiþkeni prefab da çaðýrdýðýmýzda her zaman sýfýrlandýðý için burada kontrol ettik ve swordsControl den her çarpýþmada arttýrdýk.
    private int _swordNum = 0;
    public int SwordNum { get =>_swordNum; set => _swordNum = value; }

    //Bölümde kaç adet kýlýç fýrlatýlacaðý
    [Header("Toplam Kýlýç Sayýsý")]
    [SerializeField] private int _swordCount;
    public int SwordCount { get => _swordCount; set => _swordCount = value; }

    [Header("Kýlýç Fýrlatma Hýzý")]
    [SerializeField] private float _moveSpeed;
    public float MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }

    [Header("Sword Prefab")]
    [SerializeField] private GameObject _sword;
    public GameObject SwordPrefab { get => _sword; set => _sword = value; }

    [Header("Ýcon Prefab")]
    [SerializeField] private GameObject _icon;
    public GameObject IconPrefab { get => _icon; set => _icon = value; }

    [Header("Ýlk iconun pozisyonu")]
    [SerializeField] private Vector2 _iconPos;
    public Vector2 IconPos { get => _iconPos; set => _iconPos = value; }

    [Header("Ýconlarýn arasýndaki mesafe")]
    [SerializeField] private float _iconAltAltaSiralamaDegeri;
    public float IconAltAltaSiralamaDegeri { get => _iconAltAltaSiralamaDegeri; set => _iconAltAltaSiralamaDegeri = value; }



}
