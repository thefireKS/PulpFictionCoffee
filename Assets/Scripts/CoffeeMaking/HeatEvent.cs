using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HeatEvent : MonoBehaviour
{
    [SerializeField] private RectTransform heatBar;
    [SerializeField] private RectTransform heatingPlace;
    [SerializeField] private RectTransform target;
    [Space(5)]
    [SerializeField] private float heatingPlaceSpeed = 2f;
    [SerializeField] private float targetSpeed = 1f;
    [Space(5)] 
    [SerializeField] private float timeToWin = 10f;

    private float heatingPlaceMax, heatingPlaceMin;
    private float targetMax, targetMin;

    private Vector2 heatingPlacePos;
    private float distance;

    private float startTime;
    private float timeOnHeat = 0f;

    public static Action isHeaten;
    private void OnEnable()
    {
        heatingPlaceMax = heatBar.rect.width - heatingPlace.rect.width / 2;
        heatingPlaceMin = heatingPlace.rect.width / 2;
        
        targetMax = heatBar.rect.width - target.rect.width / 2;
        targetMin = target.rect.width / 2;

        startTime = Time.time;
        
        heatingPlacePos = new Vector2(Random.Range(heatingPlaceMin,heatingPlaceMax),0);
        
        distance = Mathf.Abs(heatingPlace.anchoredPosition.x - heatingPlacePos.x);
    }

    private void OnDisable()
    {
        timeOnHeat = 0f;
    }

    private void Update()
    {
        if (timeOnHeat > timeToWin)
        {
            isHeaten?.Invoke();
            gameObject.SetActive(false);
        }

        PositionCalibration();
        
        PlayerMovement();
        
        HeatingPlaceMovement();
    }

    private void PositionCalibration()
    {
        if (target.anchoredPosition.x < targetMin)
            target.anchoredPosition = new Vector2(targetMin,0);
        if (target.anchoredPosition.x > targetMax)
            target.anchoredPosition = new Vector2(targetMax,0);

        if (heatingPlace.anchoredPosition.x < heatingPlaceMin)
            heatingPlace.anchoredPosition = new Vector2(heatingPlaceMin, 0);
        if (heatingPlace.anchoredPosition.x > heatingPlaceMax)
            heatingPlace.anchoredPosition = new Vector2(heatingPlaceMax, 0);
    }

    private void PlayerMovement()
    {
        var xTargetPos = Input.GetAxis("Horizontal") * targetSpeed;
        target.anchoredPosition = new Vector2(target.anchoredPosition.x + xTargetPos, 0);

        var rightPart = heatingPlace.anchoredPosition.x + heatingPlace.rect.width / 2;
        var leftPart = heatingPlace.anchoredPosition.x - heatingPlace.rect.width / 2;

        if (target.anchoredPosition.x >= leftPart && target.anchoredPosition.x <= rightPart)
            timeOnHeat += Time.deltaTime;
    }

    private void HeatingPlaceMovement()
    {
        float distanceCovered = (Time.time - startTime) * heatingPlaceSpeed;
        float progress = distanceCovered / distance;
        
        heatingPlace.anchoredPosition = Vector2.Lerp(heatingPlace.anchoredPosition,heatingPlacePos,progress);
        
        if(Mathf.Abs(heatingPlace.anchoredPosition.x - heatingPlacePos.x) > 5f) return;
        
        heatingPlacePos = new Vector2(Random.Range(heatingPlaceMin,heatingPlaceMax),0);
        distance = Mathf.Abs(heatingPlace.anchoredPosition.magnitude - heatingPlacePos.magnitude);
        startTime = Time.time;
    }
}
