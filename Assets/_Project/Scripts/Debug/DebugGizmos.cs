using UnityEngine;

namespace RetroSlice.Debugging
{
    public class DebugGizmos : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform _rayOrigin;
        [SerializeField] private CharacterController _controller;

        [Header("Tuning")]
        [SerializeField] private float _forwardLength = 3f;
        [SerializeField] private float _groundMarkerRadius = 0.08f;
        private void OnDrawGizmosSelected()
        {
            Transform originT = _rayOrigin != null ? _rayOrigin : transform;

            Vector3 origin = originT.position;
            Vector3 dir = originT.forward;

            Gizmos.DrawLine(origin, origin + dir * _forwardLength);

            if (_controller == null)
                return;

            Vector3 centerWorld = transform.TransformPoint(_controller.center);
            float bottomOffset = (_controller.height * 0.5f) - _controller.radius;
            Vector3 bottom = centerWorld + Vector3.down * bottomOffset;

            Gizmos.DrawSphere(bottom, _groundMarkerRadius);
        }
    }
}