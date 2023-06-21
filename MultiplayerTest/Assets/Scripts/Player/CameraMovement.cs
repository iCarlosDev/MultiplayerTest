using System;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private PlayerComponentStorage _playerComponentStorage;
    
    [SerializeField] private Transform _bodyAimObject;

    [SerializeField] private float _mouseSensitivity; 
    
    private float _xRotation = 0f;

    private void Awake()
    {
        _playerComponentStorage = GetComponent<PlayerComponentStorage>();
    }

    private void Update()
    {
        MoveBody();
    }

    private void MoveBody()
    {
        Debug.Log(_playerComponentStorage.PlayerInputs.Camera.MouseVertical.ReadValue<float>());
        _bodyAimObject.transform.position = new Vector3(0f, _bodyAimObject.transform.position.y + _playerComponentStorage.PlayerInputs.Camera.MouseVertical.ReadValue<float>() * _mouseSensitivity * Time.deltaTime, _bodyAimObject.transform.position.z);
    }
}
