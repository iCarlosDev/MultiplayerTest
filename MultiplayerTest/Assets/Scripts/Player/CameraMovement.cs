using System;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private PlayerComponentStorage _playerComponentStorage;
    
    [SerializeField] private Transform _middleSpine;

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

    /*private void MoveBody()
    {
        if (_playerComponentStorage.PlayerInputs.Camera.MouseMovement.ReadValue<Vector2>().magnitude == 0f) return;

        Debug.Log("Rotating!");
        
        float mouseX = _playerComponentStorage.PlayerInputs.Camera.MouseMovement.ReadValue<Vector2>().x * _mouseSensitivity * Time.deltaTime;
        float mouseY = _playerComponentStorage.PlayerInputs.Camera.MouseMovement.ReadValue<Vector2>().y * _mouseSensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -60f, 60f);
        
        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        _middleSpine.Rotate(Vector3.up * mouseX);
    }*/
    
    private void MoveBody()
    {
        if (_playerComponentStorage.PlayerInputs.Camera.MouseMovement.ReadValue<Vector2>().magnitude == 0f) return;

        Debug.Log("Rotating!");

        float mouseX = _playerComponentStorage.PlayerInputs.Camera.MouseMovement.ReadValue<Vector2>().x * _mouseSensitivity * Time.deltaTime;
        float mouseY = _playerComponentStorage.PlayerInputs.Camera.MouseMovement.ReadValue<Vector2>().y * _mouseSensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -60f, 60f);

        Quaternion targetRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x + mouseY, 0f, 0f);
        // Ajusta la rotación de la "spine" en tu modelo riggeado según corresponda

        // Aplicar la rotación al hueso de la "spine"
        // Aquí necesitarás acceder al hueso correspondiente en tu modelo y aplicar la rotación
        // En este ejemplo, supongamos que tienes una referencia al objeto de la "spine" llamado "_middleSpine"
        _middleSpine.transform.localRotation = targetRotation;

        _middleSpine.transform.Rotate(Vector3.up * mouseX);
    }
}
