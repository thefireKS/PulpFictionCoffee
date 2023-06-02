using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeAssemble : MonoBehaviour
{
    public static CoffeeAssemble instance;
    public AssembleStep assembleStep;
    public CoffeeExtras coffeeExtras;

    public CoffeeExtras currentRecipe;
    
    private void Start()
    {
        if (instance == null)
            instance = this;
        else if(instance != this)
            Destroy(this);
    }
    
    public enum AssembleStep
    {
        PourWater,
        SetNet,
        AddCoffee,
        SetUpperPart,
        CoffeeHeating,
        PourCoffee,
        AddExtras
    }

    [Serializable]
    public class CoffeeExtras
    {
        public bool Milk;
        public bool Cream;
        public int Sugar = 0;
    }
}
