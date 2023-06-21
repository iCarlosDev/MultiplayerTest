using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerComponentStorage _playerComponentStorage;
    
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _currentSpeed;

    private void Awake()
    {
        _playerComponentStorage = GetComponent<PlayerComponentStorage>();
        
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (_playerComponentStorage.PlayerInputs.Movement.WASD.ReadValue<Vector2>().magnitude == 0f) return;

        float horizontal = _playerComponentStorage.PlayerInputs.Movement.WASD.ReadValue<Vector2>().x;
        float vertical = _playerComponentStorage.PlayerInputs.Movement.WASD.ReadValue<Vector2>().y;

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        _characterController.Move(direction * _currentSpeed * Time.deltaTime);
    }
}
