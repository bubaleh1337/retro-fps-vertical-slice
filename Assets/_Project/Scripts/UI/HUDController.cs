using RetroSlice.Combat;
using TMPro;
using UnityEngine;

namespace RetroSlice.UI
{
    public class HUDController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _ammoText;
        [SerializeField] private HitScanShooter _weapon;

        void Update()
        {
            if (_ammoText == null) return;

            if (_weapon == null)
            {
                _ammoText.text = "Ammo: --/--";
                return;
            }

            _ammoText.text = $"Ammo: {_weapon.CurrentAmmo}/{_weapon.MaxAmmo}";
        }
    }
}
