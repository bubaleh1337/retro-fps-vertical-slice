using UnityEngine;

namespace RetroSlice.Weapons
{
    [CreateAssetMenu(menuName = "RetroSlice/Weapon Config", fileName = "WeaponConfig")]
    public class WeaponConfig : ScriptableObject
    {

        [SerializeField] private float _range = 50f;
        [SerializeField] private float _fireCooldown = 0.1f;
        [SerializeField] private int _maxAmmo = 12;
        [SerializeField] private float _reloadDuration = 1.0f;

        public float Range => _range;
        public float FireCooldown => _fireCooldown;
        public int MaxAmmo => _maxAmmo;
        public float ReloadDuration => _reloadDuration;
    }
}
