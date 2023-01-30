using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private Transform gunPoint;
    [SerializeField] private GameObject ammo;

    [SerializeField] private int maxAmmo;
    public int currentAmmo;

    private bool _isReloading;
    [SerializeField] private float reloadTime;

    [SerializeField] private int fireRate;
    private float _timeSinceLastShot;
    
    private static readonly int Attack = Animator.StringToHash("Attack");

    void Start()
    {
        // get components
        _animator = GetComponent<Animator>();
        
        // load magazine on Start
        currentAmmo = maxAmmo;
        
        // add actions
        InputManager.ShootInput += Shoot;
        InputManager.ReloadInput += Reload;
    }
    
    private bool CanShoot() => !_isReloading && _timeSinceLastShot > 1f / (fireRate / 60f);
    private void Shoot()
    {
        if(currentAmmo < 0) return;
        if(!CanShoot()) return;
        _animator.SetTrigger(Attack);
        Quaternion ammoRotation = transform.localScale.x > 0 ? transform.rotation : new Quaternion(0f, 0f, 180f,0f);
        Instantiate(ammo, gunPoint.position, ammoRotation);
        _timeSinceLastShot = 0;
        currentAmmo--;
    }

    private void Reload()
    {
        if (!_isReloading) StartCoroutine(Reloading());
    }

    private IEnumerator Reloading()
    {
        _isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        _isReloading = false;
    }

    private void Update()
    {
        _timeSinceLastShot += Time.deltaTime;
    }
}
