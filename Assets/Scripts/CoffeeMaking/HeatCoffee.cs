using System;
using UnityEngine;

public class HeatCoffee : MonoBehaviour
{
    [SerializeField] private WaterBase waterBase;
    [Space(5)] 
    [SerializeField] private GameObject heatBar;

    private bool heated;

    public static Action<int> pourCoffee;

    private void OnEnable() => HeatEvent.isHeaten += CoffeeIsHeated;

    private void OnDisable() => HeatEvent.isHeaten -= CoffeeIsHeated;

    private void Update()
    {
        if(waterBase.spoonsOfCoffee <= 0) return;

        if(Input.GetKey(KeyCode.Space))
            heatBar.SetActive(true);
    }

    private void OnMouseDown()
    {
        if(!heated) return;
        pourCoffee?.Invoke(waterBase.spoonsOfCoffee);
        waterBase.spoonsOfCoffee = 0;
    }

    private void CoffeeIsHeated()
    {
        heated = true;
    }
}
