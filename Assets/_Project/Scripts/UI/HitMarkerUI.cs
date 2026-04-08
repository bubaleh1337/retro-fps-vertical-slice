using UnityEngine;

namespace RetroSlice.UI
{

    public class HitMarkerUI : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _group;
        [SerializeField] private float _showDuration = 0.08f;
        private float _hideAt;

        private void Update()
        {
            if (_group != null && _group.alpha > 0f && Time.time >= _hideAt) _group.alpha = 0f;
        }

        public void ShowHit()
        {
            if (_group == null) return;
            _group.alpha = 1f;
            _hideAt = Time.time + _showDuration;
        }
    }
}
