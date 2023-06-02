using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private int damage = 1;
        
    [SerializeField] private float velocity;
    [SerializeField] private float destroyDistance = 10;

    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        Transform projectileTransform = transform;
        projectileTransform.position += projectileTransform.right * (velocity * Time.fixedDeltaTime);
        if (Vector3.Distance(_startPosition, transform.position) > destroyDistance)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyCore>().TakeDamage(damage);
        }
        if(!other.CompareTag("Player") && !other.CompareTag("Ammo"))
            Destroy(gameObject);
    }
}