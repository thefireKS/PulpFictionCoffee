using System;
using UnityEngine;

public class CreamInteract : MonoBehaviour
{
    public static Action addCream;

    private void OnMouseDown()
    {
        addCream?.Invoke();
    }
}
