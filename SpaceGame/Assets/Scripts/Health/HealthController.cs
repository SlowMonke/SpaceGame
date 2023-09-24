using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private float _currentHealth;

    [SerializeField]
    private float _maximumHealth;

    public float RemainingHealthPercentage
    {
        get
        {
            return _currentHealth / _maximumHealth;
        }
    }

    public UnityEvent OnDied;

    public void TakeDamage(float damageAmount)
    {

        if(_currentHealth == 0)
        {
            return;
        }

        _currentHealth -= damageAmount;

        if(_currentHealth < 0)
        {
            _currentHealth = 0;
        }

        if(_currentHealth == 0)
        {
            OnDied.Invoke();
        }
    }

    public void AddHealth(float amountToAdd)
    {

        if(_currentHealth == _maximumHealth)
        {
            return;
        }

        _currentHealth += amountToAdd;
        {
            _currentHealth = _maximumHealth;
        }
    }
}
