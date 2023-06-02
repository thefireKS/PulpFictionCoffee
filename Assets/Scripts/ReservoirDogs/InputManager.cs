using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public KeyCode shootKey;
    public KeyCode reloadKey;

    public static Action ShootInput;
    public static Action ReloadInput;

    private void Update()
    {
        if(Input.GetKey(shootKey))
            ShootInput?.Invoke();
        if(Input.GetKeyDown(reloadKey))
            ReloadInput?.Invoke();
    }
}
