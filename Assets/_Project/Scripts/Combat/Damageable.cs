using UnityEngine;

namespace RetroSlice.Combat
{
    public class Damageable : MonoBehaviour
    {
        [SerializeField] private int _maxHealth = 100;

        [SerializeField] private float _flashDuration = 0.1f;
        [SerializeField] private Color _flashColor = new Color(1f, 0.2f, 0.2f, 1f);

        private int _currentHealth;
        private float _flashEndTime;
        private Renderer _renderer;
        private Color _originalColor;
        private bool _isFlashing;

        private void Awake()
        {
            _currentHealth = _maxHealth;
            _renderer = GetComponent<Renderer>();
            if (_renderer != null ) _originalColor = _renderer.material.color;
        }

        private void Update()
        {
            if (_isFlashing && _renderer != null && Time.time >= _flashEndTime)
            {
                _renderer.material.color = _originalColor;
                _isFlashing = false;
            }
        }

        public void TakeDamage(int amount)
        {
            if (amount <= 0) return;

            _currentHealth -= amount;
            Debug.Log($"{name} took {amount} damage. HP = {_currentHealth}.", this);

            if (_renderer != null)
            {
                _renderer.material.color = _flashColor;
                _isFlashing = true;
                _flashEndTime = Time.time + _flashDuration;
            }

            if (_currentHealth <= 0) Death();
        }
        void Death()
        {
            Debug.Log($"{name} died.", this);
            gameObject.SetActive(false);
        }
    }
}