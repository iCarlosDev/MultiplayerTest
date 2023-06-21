using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private PlayerComponentStorage _playerComponentStorage;
    [SerializeField] private Animator _animator;

    private void Awake()
    {
        _playerComponentStorage = GetComponent<PlayerComponentStorage>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        SetLocomotionAnimations();
        JumpAnimation();
    }

    private void SetLocomotionAnimations()
    {
        _animator.SetFloat("X", _playerComponentStorage.PlayerInputs.Movement.WASD.ReadValue<Vector2>().x);
        _animator.SetFloat("Y", _playerComponentStorage.PlayerInputs.Movement.WASD.ReadValue<Vector2>().y);
        _animator.SetFloat("CurrentSpeed", _playerComponentStorage.PlayerMovement.CurrentSpeed);
    }

    private void JumpAnimation()
    {
        switch (_playerComponentStorage.PlayerMovement._playerStatesEnum)
        {
            case PlayerMovement._playerStates.Jumping:
                _animator.SetTrigger("Jump");
                break;
            case PlayerMovement._playerStates.Falling:
                _animator.SetTrigger("Land");
                break;
        }
    }
}
