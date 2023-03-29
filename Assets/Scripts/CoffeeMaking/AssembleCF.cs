using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssembleCF : MonoBehaviour
{
    [SerializeField] private GameObject assembledCF;
    [SerializeField] private WaterBase waterBase;

    private void OnMouseDown()
    {
        if (!waterBase.isFilledWithWater || !waterBase.isSetWithSeto4ka || waterBase.spoonsOfCoffee <= 0) return;
        waterBase.gameObject.SetActive(false);
        assembledCF.SetActive(true);
        gameObject.SetActive(false);
    }
}
