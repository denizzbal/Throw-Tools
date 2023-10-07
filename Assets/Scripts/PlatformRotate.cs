using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlatformRotate : MonoBehaviour
{
    [SerializeField] private float RotationSpeed;
    private bool IsSpin;
    private float _randomAxis;
    private float _randomDuration;
    void Start()
    {
        RandomSpin();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(RotationSpeed * Time.deltaTime * -Vector3.forward);
        transform.DORotate(Vector3.forward * 300, 5, RotateMode.FastBeyond360);
    }

    void RandomSpin()
    {
        _randomAxis = Random.Range(-180f, 180f);
        _randomDuration = Random.Range(5f, 10f);
    }
}
