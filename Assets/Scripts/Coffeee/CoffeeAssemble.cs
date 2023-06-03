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

        public static bool operator !=(CoffeeExtras ce1, CoffeeExtras ce2) {
            if (ce1.Milk == ce2.Milk && ce1.Cream == ce2.Cream && ce1.Sugar == ce2.Sugar) return false;
            else return true;
        }

        public static bool operator ==(CoffeeExtras ce1, CoffeeExtras ce2) {
            if (ce1.Milk == ce2.Milk && ce1.Cream == ce2.Cream && ce1.Sugar == ce2.Sugar) return true;
            else return false;
        }
    }
}
