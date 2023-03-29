using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeInteract : MonoBehaviour
{
    [SerializeField] private WaterBase WaterBase;
    [Space(5)] 
    [SerializeField] private Sprite coffeeFilledBase;
    [Space(5)]
    [SerializeField] private Transform pulledPosition;

    private SpriteRenderer waterBaseSpriteRenderer;
    
    private bool isPulledOut = false;

    private void Start()
    {
        waterBaseSpriteRenderer = WaterBase.gameObject.GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        if(isPulledOut && WaterBase.isFilledWithWater && WaterBase.isSetWithSeto4ka)
            WaterBase.spoonsOfCoffee++;

        if (WaterBase.spoonsOfCoffee > 0)
            waterBaseSpriteRenderer.sprite = coffeeFilledBase;
        
        
        if (isPulledOut) return;
        transform.position = pulledPosition.position;
        isPulledOut = true;
    }
}
