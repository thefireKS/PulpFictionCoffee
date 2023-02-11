using System;
using TMPro;
using UnityEngine;

public class AmmoCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammoCounterText;
    [SerializeField] private Gun gun;

    private void OnEnable() => Gun.ammoCounterUpdateAction += UpdateAmmoText;
    private void OnDisable() => Gun.ammoCounterUpdateAction -= UpdateAmmoText;
    private void UpdateAmmoText()
    {
        ammoCounterText.text = gun.currentAmmo + "/" + gun.maxAmmo;
    }
}