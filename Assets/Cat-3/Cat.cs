using UnityEngine;
using UnityEngine.Events;

public class Cat : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float _minHealth = 0;

    private float _health;

    public UnityEvent _changeHealth;
    public UnityEvent _init;

    private void Start()
    {
        Health = _maxHealth;
        _init.Invoke();
    }

    public float Health
    {
        get
        {
            return _health;
        }
        private set
        {
            if (value >= _minHealth && value <= _maxHealth)
                _health = value;
            else if (value < _minHealth)
                _health = _minHealth;
            else
                _health = _maxHealth;

            _changeHealth.Invoke();
        }
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
            return;

        Health -= damage;
    }

    public void AddHealth(float health)
    {
        if (health < 0)
            return;

        Health += health;
    }
}
