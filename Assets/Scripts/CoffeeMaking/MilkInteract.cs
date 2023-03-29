using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkInteract : MonoBehaviour
{
    public static Action pourMilk;

    private void OnMouseDown()
    {
        pourMilk?.Invoke();
    }
}
