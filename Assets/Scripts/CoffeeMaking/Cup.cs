using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cup : MonoBehaviour
{
    public bool isFilledWithCoffee = false;
    public int spoonsOfCoffee = 0;
    
    public int creamDose = 0;

    public bool hasMilk = false;

    public int spoonsOfSugar = 0;

    [SerializeField] private SpriteRenderer coffee;
    [SerializeField] private Color coffeeColor;
    [SerializeField] private Color coffeeMilkColor;
    [Space(5)]
    [SerializeField] private GameObject cream;

    private void OnEnable()
    {
        HeatCoffee.pourCoffee += CoffeeSetter;
        MilkInteract.pourMilk += AddMilk;
        CreamInteract.addCream += AddCream;
        SugarInteract.addSugar += AddSugar;
    }

    private void OnDisable()
    {
        HeatCoffee.pourCoffee -= CoffeeSetter;
        MilkInteract.pourMilk -= AddMilk;
        CreamInteract.addCream -= AddCream;
        SugarInteract.addSugar -= AddSugar;
    }

    private void OnMouseDown()
    { 
        isFilledWithCoffee = false;
        spoonsOfCoffee = 0;
        
        coffee.gameObject.SetActive(false);
        coffee.color = coffeeColor;
        
        creamDose = 0;
        cream.gameObject.SetActive(false);
        
        hasMilk = false;
        
        spoonsOfSugar = 0;
    }

    private void CoffeeSetter(int spoons)
    {
        if(spoons <= 0) return;
        isFilledWithCoffee = true;
        spoonsOfCoffee = spoons;
        coffee.gameObject.SetActive(true);
        coffee.color = coffeeColor;
    }

    private void AddMilk()
    {
        if(!isFilledWithCoffee)return;
        hasMilk = true;
        coffee.color = coffeeMilkColor;
    }

    private void AddCream()
    {
        if(!isFilledWithCoffee)return;
        creamDose++;
        cream.gameObject.SetActive(true);
    }

    private void AddSugar()
    {
        spoonsOfSugar++;
    }
}
