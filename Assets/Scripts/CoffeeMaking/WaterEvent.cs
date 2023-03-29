using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterEvent: MonoBehaviour
{
    [SerializeField] private Image filler;

    [SerializeField] private WaterBase waterBase;
    
    [SerializeField] private float fillCount = 0.5f;
    [SerializeField] private RectTransform waterBar;
    [SerializeField] private RectTransform target;

    private void Start()
    {
        filler.fillAmount = 0f;
    }

    private void Update()
    {
        PourWater();
        if(waterBase.isFilledWithWater)
            gameObject.SetActive(false);
    }

    private void PourWater()
    {
        if(target.anchoredPosition.y/waterBar.rect.height < filler.fillAmount) return;

        if (Input.GetKey(KeyCode.Space))
            filler.fillAmount += fillCount * Time.deltaTime;
        
        waterBase.isFilledWithWater = target.anchoredPosition.y / waterBar.rect.height < filler.fillAmount;
    }
}
