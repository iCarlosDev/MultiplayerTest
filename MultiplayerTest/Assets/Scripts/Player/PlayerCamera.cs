using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private PlayerComponentStorage _playerComponentStorage;
    
    [Header("=== CAMERA SETTINGS ===")]
    [Space(10)]
    [SerializeField] private Transform _cameraParent;
    [SerializeField] private float _mouseSensitivity;
    private float _xRotation = 0f;

    [Header("=== HEAD MOVEMENT ===")] 
    [Space(10)] 
    [SerializeField] private Transform _headTargetPoint;

    private void Awake()
    {
        _playerComponentStorage = GetComponent<PlayerComponentStorage>();
    }

    private void Update()
    {
        MoveHead();
    }

    private void MoveHead()
    {
        float horizontal = _playerComponentStorage.PlayerInputs.Camera.MouseHorizontal.ReadValue<float>() * _mouseSensitivity * Time.deltaTime;
        float vertical = _playerComponentStorage.PlayerInputs.Camera.MouseVertical.ReadValue<float>() * _mouseSensitivity * Time.deltaTime;
        
        _cameraParent.LookAt(_headTargetPoint);
        transform.Rotate(Vector3.up, horizontal);
        
        _headTargetPoint.transform.localPosition = new Vector3(_headTargetPoint.transform.localPosition.x, Mathf.Clamp(_headTargetPoint.transform.localPosition.y + vertical/50f, 1f, 2f), _headTargetPoint.transform.localPosition.z);
    }
}
