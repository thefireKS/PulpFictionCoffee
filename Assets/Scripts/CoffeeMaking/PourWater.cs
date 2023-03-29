using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PourWater : MonoBehaviour
{
    private WaterBase waterBase;
    [SerializeField] private RectTransform waterBar;
    [SerializeField] private RectTransform target;
    [SerializeField] private Image waterFill;

    private void Start()
    {
        waterBase = GetComponent<WaterBase>();
    }

    private void OnMouseDown()
    {
        if(waterBase.isFilledWithWater) return;
        
        waterBar.gameObject.SetActive(true);
        waterFill.fillAmount = 0;

        var randomAmount = Random.Range(waterBar.rect.height / 4, waterBar.rect.height);

        target.anchoredPosition = new Vector3(0,randomAmount,0);
    }
}
