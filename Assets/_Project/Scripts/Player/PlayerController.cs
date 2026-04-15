using UnityEngine;

namespace RetroSlice.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private CharacterController _controller;

        [Header("Tuning")]
        [SerializeField] private float _gravity = -20f;
        [SerializeField] private float _walkSpeed = 5f;
        [SerializeField] private float _sprintMultiplier = 1.6f;
        [SerializeField] private float _jumpHeight = 1.2f;

        private Vector3 _velocity;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");
            bool sprint = Input.GetKey(KeyCode.LeftShift);

            Vector3 move = (transform.right * x) + (transform.forward * z);
            float speed = sprint ? _walkSpeed * _sprintMultiplier : _walkSpeed;
            _controller.Move(move * speed * Time.deltaTime);

            if (_controller.isGrounded && _velocity.y < 0f) _velocity.y = -2f;

            if (_controller.isGrounded && Input.GetKeyDown(KeyCode.Space)) _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);

            _velocity.y += _gravity * Time.deltaTime;
            _controller.Move(_velocity * Time.deltaTime);
        }
    }

}
