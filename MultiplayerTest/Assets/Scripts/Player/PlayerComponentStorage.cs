using System;
using UnityEngine;

public class PlayerComponentStorage : MonoBehaviour
{
    //GETTERS && SETTERS//
    public PlayerInputs PlayerInputs { get; private set; }
    public PlayerMovement PlayerMovement { get; private set; }

    ///////////////////////////////////////////////////

    private void Awake()
    {
        PlayerInputs = new PlayerInputs();
        PlayerMovement = GetComponent<PlayerMovement>();
    }

    private void OnEnable()
    {
        PlayerInputs.Enable();
    }

    private void OnDisable()
    {
        PlayerInputs.Disable();
    }
}
