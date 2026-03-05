using UnityEngine;
using UnityEngine.InputSystem;

namespace RetroSlice.Player
{
    public class PlayerLook : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] Transform playerRoot;
        [SerializeField] Transform cameraPivot;

        [Header("Tuning")]
        [SerializeField] private float _sensitivity = 2f;
        [SerializeField] private float _pitchMin = -80f;
        [SerializeField] private float _pitchMax = 80f;

        private float _pitch;

        private void Awake()
        {
            if (playerRoot == null) playerRoot = transform;
            if (cameraPivot == null)
            {
                Debug.LogError("PlayerLook: CameraPivot is not assigned.", this);
                enabled = false;
                return;

            }
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // Update is called once per frame
        void Update()
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            float yawDelta = mouseX * _sensitivity;
            playerRoot.Rotate(0f, yawDelta, 0f, Space.Self);

            _pitch -= mouseY * _sensitivity;
            _pitch = Mathf.Clamp(_pitch, _pitchMin, _pitchMax);
            cameraPivot.localRotation = Quaternion.Euler(_pitch, 0, 0);
            
        }
    }
}

