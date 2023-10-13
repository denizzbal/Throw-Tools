using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlatformRotate : MonoBehaviour
{
    private float _rotationSpeed;
    private LevelControl _levelControl;
    private bool _randomAxis;
    private void Awake()
    {
        _levelControl = GameObject.FindWithTag("LevelControl").GetComponent<LevelControl>();
    }

    private void Start()
    {
        _rotationSpeed = _levelControl.RotationSpeed;

        _randomAxis = Random.value > 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(_randomAxis)
            transform.Rotate(_rotationSpeed * Time.deltaTime * -Vector3.forward);
        else
            transform.Rotate(_rotationSpeed * Time.deltaTime * Vector3.forward);
    }
}
