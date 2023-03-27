using System;
using System.Collections;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;

public class Wheel : MonoBehaviour
{
    [SerializeField] private AnimationCurve speedCurve;
    [SerializeField] private float wheelSpeed;
    private float _rotateAngle;
    private float _resultAngle;

    [SerializeField] private float numberOfElements;
    private float _angleForOneElement;
    private int _resultElement;
    
    
    [SerializeField] private float minTimeToRotate, maxTimeToRotate;

    private float _timeOfStart;
    private bool _needToRotate;
    private bool _needToSlow;

    private void Awake()
    {
        _angleForOneElement = 360f / numberOfElements;
    }

    private void Update()
    {
        if(_needToRotate) RotateWheel();
    }

    private void RotateWheel()
    {
        if (_needToSlow)
        {
            _rotateAngle = -wheelSpeed * Time.deltaTime * speedCurve.Evaluate(Time.time - _timeOfStart);
        }
        else
        {
            _rotateAngle = -wheelSpeed * Time.deltaTime;
        }

        _resultAngle += _rotateAngle;
        transform.Rotate(0,0, _rotateAngle);

        if (_rotateAngle == 0)
        {
            StopRotate();
        }
    }

    public void StartRotate()
    {
        if (_needToRotate) return;
        transform.rotation = Quaternion.identity;
        _needToRotate = true;
        StartCoroutine(StartToSlow());
        Debug.Log($"Start rotate {Time.time}");
    }

    private void StopRotate()
    {
        _resultAngle = Mathf.Abs(_resultAngle);
        _needToRotate = false;
        _needToSlow = false;

        ReturnResult();
        
        Debug.Log($"Stop rotate {Time.time}\nResult angle {_resultAngle}");
        
        _resultAngle = 0;
    }

    private void ReturnResult()
    {
        var prize = _resultAngle % 360;
        Debug.Log($"Result % 360 = {prize}\nAngle1 = {_angleForOneElement}");
        prize = 4 - (Mathf.Floor(prize / _angleForOneElement));
        _resultElement = (int)prize;
        Debug.Log($"Your element is {_resultElement}");
    }

    private IEnumerator StartToSlow()
    {
        yield return new WaitForSeconds(Random.Range(minTimeToRotate,maxTimeToRotate));
        _needToSlow = true;
        Debug.Log($"Start to slow {Time.time}");
        _timeOfStart = Time.time;
    }
}
