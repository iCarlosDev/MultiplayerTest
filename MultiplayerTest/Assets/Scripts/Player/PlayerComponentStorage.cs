using UnityEngine;

public class PlayerComponentStorage : MonoBehaviour
{
    private PlayerInputs _playerInputs;

    //GETTERS && SETTERS//
    public PlayerInputs PlayerInputs => _playerInputs;

    /////////////////////////////////////////////////////
    
    private void Awake()
    {
        _playerInputs = new PlayerInputs();
    }

    private void OnEnable()
    {
        _playerInputs.Enable();
    }

    private void OnDisable()
    {
        _playerInputs.Disable();
    }
}
