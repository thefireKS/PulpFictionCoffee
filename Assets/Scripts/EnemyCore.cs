using System;
using UnityEngine;

public class EnemyCore : MonoBehaviour
{
    [SerializeField] private int maxHitPoints;
    [SerializeField] private int scoreAmount;
    private int _currentHitPoints;

    public static Action<int> giveScore;
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
        if (_currentHitPoints > 0)
            return;
        giveScore?.Invoke(scoreAmount);
        Destroy(gameObject);
    }
}