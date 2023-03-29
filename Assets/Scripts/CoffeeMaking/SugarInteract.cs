using System;
using UnityEngine;

public class SugarInteract : MonoBehaviour
{
    public static Action addSugar;

    private void OnMouseDown()
    {
        addSugar?.Invoke();
    }
}
