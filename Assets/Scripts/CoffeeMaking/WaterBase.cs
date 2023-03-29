using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBase : MonoBehaviour
{
    [SerializeField] private Sprite emptyBase;
    
    public int spoonsOfCoffee = 0;
    public bool isSetWithSeto4ka = false;
    public bool isFilledWithWater = false;
    
    private PourWater water;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        water = GetComponent<PourWater>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnDisable()
    {
        spriteRenderer.sprite = emptyBase;
    }

    private void Update()
    {
        if (!isFilledWithWater || !isSetWithSeto4ka)
            spoonsOfCoffee = 0;
        
        if (spoonsOfCoffee >= 5)
            spoonsOfCoffee = 5;
    }
}
