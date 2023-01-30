using UnityEngine;

public class EnemyCore : MonoBehaviour
{
    [SerializeField] private int maxHitPoints;
    private int _currentHitPoints;

    private void Start()
    {
        gameObject.tag = "Enemy";
        _currentHitPoints = maxHitPoints;
    }

    public void TakeDamage(int damage)
    {
        _currentHitPoints -= damage;
        CheckHealth();
    }

    private void CheckHealth()
    {
        if(_currentHitPoints <= 0) Destroy(gameObject);
    }
}