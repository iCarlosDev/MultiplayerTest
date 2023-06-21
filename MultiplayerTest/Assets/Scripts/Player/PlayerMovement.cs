using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerComponentStorage _playerComponentStorage;
    
    [SerializeField] private CharacterController _characterController;

    [Header("=== MOVEMENT SETTINGS ===")]
    [Space(10)]
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _currentSpeed;

    [Header("=== JUMP SETTINGS ===")] 
    [Space(10)] 
    [SerializeField] private float _jumpHeight;

    [Header("=== GROUND CHECK ===")] 
    [Space(10)] 
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _groundRadius;
    [SerializeField] private bool _isGrounded;

    [Header("=== PLAYER STATES ===")] 
    [Space(10)] 
    [SerializeField] public _playerStates _playerStatesEnum;
    public enum _playerStates
    {
        Idle,
        Walking,
        Running,
        Jumping,
        Falling,
    }

    [Header("=== GRAVITY SETTINGS ===")] 
    [Space(10)] 
    [SerializeField] private Vector3 _velocity;
    [SerializeField] private float _gravity;

    //GETTERS && SETTERS//
    public float CurrentSpeed => _currentSpeed;
    public _playerStates PlayerStatesEnum => _playerStatesEnum;

    ////////////////////////////////////////////////
    
    private void Awake()
    {
        _playerComponentStorage = GetComponent<PlayerComponentStorage>();

        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        SetGravity();
        
        MovePlayer();
        Sprint();
        Jump();
    }

    private void MovePlayer()
    { 
        float horizontal = _playerComponentStorage.PlayerInputs.Movement.WASD.ReadValue<Vector2>().x;
        float vertical = _playerComponentStorage.PlayerInputs.Movement.WASD.ReadValue<Vector2>().y;

        Vector3 direction = transform.right * horizontal + transform.forward * vertical;
        
        _characterController.Move(direction.normalized * (_currentSpeed * Time.deltaTime));

        if (!_isGrounded || _currentSpeed > 2) return;
     
        if (horizontal != 0 || vertical != 0)
        {
            _playerStatesEnum = _playerStates.Walking;
        }
        else
        {
            _playerStatesEnum = _playerStates.Idle;
        }
    }

    private void Sprint()
    {
        if (!_isGrounded || _characterController.velocity.magnitude < 0.1f) return;

        if (_playerComponentStorage.PlayerInputs.Movement.Sprint.IsPressed())
        {
            _currentSpeed = _maxSpeed;
            _playerStatesEnum = _playerStates.Running;
        }
        else
        {
            _currentSpeed = _minSpeed;
        }
    }
    
    private void Jump()
    {
        if (_playerComponentStorage.PlayerInputs.Movement.Jump.triggered)
        {
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
            _playerStatesEnum = _playerStates.Jumping;
            Invoke(nameof(Fall), 0.3f);
        }
    }

    private void Fall()
    {
        _playerStatesEnum = _playerStates.Falling;
    }
    
    private void SetGravity()
    {
        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundRadius, _groundMask);
        
        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        _velocity.y += _gravity * Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);
    }
}
