using TMPro;
using UnityEngine;

public class AmmoCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammoCounterText;
    [SerializeField] private Gun gun;

    private void Update()
    {
        ammoCounterText.text = gun.currentAmmo + "/" + gun.maxAmmo;
    }
}
