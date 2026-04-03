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
        [SerializeField] private float _fireCooldown = 0.1f;

        private float _nextFireTime;

        void Awake()
        {

        }

        void Update()
        {
            if (Input.GetMouseButton(0) && Time.time >= _nextFireTime)
            {
                _nextFireTime = Time.time + _fireCooldown;
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
            else
            {
                // I don't figure out where to take the "end" variable
            }
            Debug.DrawLine(origin, end, Color.red, 0.1f);
        }
    }
}
