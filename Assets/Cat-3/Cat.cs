using UnityEngine;
using UnityEngine.Events;

public class Cat : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float _minHealth = 0;

    public UnityEvent _changeHealth;
    public UnityEvent _init;

    private void Start()
    {
        Health = _maxHealth;
        _init.Invoke();
    }

    public float Health { get; private set; }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            return;

        if (Health > damage)
            Health -= damage;
        else
            Health = _minHealth;

        _changeHealth.Invoke();
    }

    public void AddHealth(float health)
    {
        if (health < 0)
            return;

        if (Health + health > _maxHealth)
            Health = _maxHealth;
        else
            Health += health;

        _changeHealth.Invoke();
    }
}
