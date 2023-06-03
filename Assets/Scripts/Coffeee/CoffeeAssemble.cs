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
        AddExtras,
        PourCoffee,
        End
    }

    [Serializable]
    public class CoffeeExtras
    {
        protected bool Equals(CoffeeExtras other)
        {
            return Milk == other.Milk && Cream == other.Cream && Sugar == other.Sugar;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((CoffeeExtras) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Milk, Cream, Sugar);
        }

        public bool Milk;
        public bool Cream;
        public int Sugar = 0;

        public static bool operator ==(CoffeeExtras obj1, CoffeeExtras obj2)
        {
            return obj1.Cream == obj2.Cream && obj1.Milk == obj2.Milk && obj1.Sugar == obj2.Sugar;
        }

        public static bool operator !=(CoffeeExtras obj1, CoffeeExtras obj2)
        {
            return !(obj1 == obj2);
        }
    }
}
