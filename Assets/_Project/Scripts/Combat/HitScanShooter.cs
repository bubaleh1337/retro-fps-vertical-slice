using UnityEngine;

namespace RetroSlice.Combat
{
    public class HitScanShooter : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform _rayOrigin;
        [SerializeField] private Transform _muzzle;

        [Header("Tuning")]
        [SerializeField] private float _range = 50f;
        [SerializeField] private float _fireCooldown = 0.1f; // how long we must wait between shots (seconds)
        [SerializeField] private int _maxAmmo = 12;
        [SerializeField] private float _reloadDuration = 1.0f;

        [Header("Running")]
        private float _nextFireTime;
        private int _currentAmmo;
        private bool _isReloading;
        private float _reloadEndTime;

        void Awake()
        {
            _currentAmmo = _maxAmmo;
        }

        void Update()
        {
            if (_isReloading && Time.time >= _reloadEndTime)
            {
                _isReloading = false;
                _currentAmmo = _maxAmmo;
            }
            if (Input.GetKeyDown(KeyCode.R) && !_isReloading && _currentAmmo < _maxAmmo)
            {
                _isReloading = true;
                _reloadEndTime = Time.time + _reloadDuration; // reload will be finished at this absolute time
                Debug.Log($"On reload start: Time.time = {Time.time}, _reloadlEndTime = {_reloadEndTime}");
                return;
            }
            if (!_isReloading && _currentAmmo > 0 && Input.GetMouseButton(0) && Time.time >= _nextFireTime)
            {
                _nextFireTime = Time.time + _fireCooldown; // the earliest time when shooting is allowed again
                Debug.LogFormat($"On fire: Time.time = {Time.time}, _fireCooldown = {_fireCooldown}");
                _currentAmmo--;
                Fire();
            }
            
        }
        void Fire()
        {
            Vector3 origin = _rayOrigin.position;
            Vector3 direction = _rayOrigin.forward;
            Vector3 end = origin + direction * _range;

            if (Physics.Raycast(origin, direction, out RaycastHit hit,_range))
            {
                end = hit.point;
            }
            Debug.DrawLine(origin, end, Color.red, 0.1f);
        }
    }
}
