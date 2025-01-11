using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool IsMoving = false;
    public bool IsRunning = false;

    [SerializeField] CharacterController _controller;
    [Tooltip("Walking speed")]
    [SerializeField] float _speed = 12f;
    [Tooltip("Running speed")]
    [SerializeField] float _runSpeed = 3f;
    [Tooltip("Gravity / fall speed")]
    [SerializeField] float _gravity = -15; //-9.81f;
    [Tooltip("Jump force")]
    [SerializeField] float _jumpForce = 3f;
    [Header("Ground :")]
    [Tooltip("Radius check")]
    [SerializeField] float _groundDistance = 0.4f;
    [Tooltip("Position to check if grounded")]
    [SerializeField] Transform _groundCheck;
    [Tooltip("Layer of ground checking")]
    [SerializeField] LayerMask _groundMask;

    Vector3 _velocity;
    Vector3 _directionSpeed;
    bool _isGrounded;

    void Update()
    {
        if (!GameManager.Instance.Ui.IsGamePause)
        {
            //Ground check
            _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);

            if (_isGrounded && _velocity.y < 0)
            {
                _velocity.y = -2f;
            }

            //Move
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            if (move.magnitude > 0)
                IsMoving = true;
            else
                IsMoving = false;

            //Run
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _controller.Move(move * (_speed + _runSpeed) * Time.deltaTime);
                IsRunning = true;
            }
            else
            {
                _controller.Move(move * _speed * Time.deltaTime);
                IsRunning = false;
            }

            //Jump
            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                _velocity.y = Mathf.Sqrt(_jumpForce * -2f * _gravity);
            }

            _velocity.y += _gravity * Time.deltaTime;

            _controller.Move(_velocity * Time.deltaTime);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_groundCheck.position, _groundDistance);
    }
}
