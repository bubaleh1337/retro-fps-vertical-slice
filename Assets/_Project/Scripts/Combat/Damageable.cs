using UnityEngine;

namespace RetroSlice.Combat
{
    public class Damageable : MonoBehaviour
    {
        [SerializeField] private int _maxHealth = 100;

        private int _currentHealth;

        private void Awake()
        {
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(int amount)
        {
            if (amount <= 0) return;

            _currentHealth -= amount;
            Debug.Log($"{name} took {amount} damage. HP = {_currentHealth}.", this);

            if (_currentHealth <= 0) Death();
        }
        void Death()
        {
            Debug.Log($"{name} died.", this);
            gameObject.SetActive(false);
        }
    }
}