using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCupboard : MonoBehaviour
{
    private bool isOpened = false;
    private void OnMouseDown()
    {
        var direction = isOpened ? Vector3.right * 2f : Vector3.left * 2f;  
        transform.position += direction;
        isOpened = !isOpened;
    }
}
