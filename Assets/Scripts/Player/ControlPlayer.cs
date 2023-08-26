using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Realtime;
using Photon.Pun;

[RequireComponent(typeof(IShoot))]
[RequireComponent(typeof(PlayerHealth))]
public class ControlPlayer : MonoBehaviourPunCallbacks
{
    private PlayerInput _playerInput;
    private IShoot _iShoot;
    private IMovable _iMovable;
    private ILook _iLook;
    private Vector2 _direction;
    private Vector2 _rotation;
    private PlayerHealth _playerHealth;

    private void Awake()
    {
        if (!photonView.IsMine)
            return;
        _playerInput = new PlayerInput();
        _iShoot = GetComponent<IShoot>();
        _iMovable = GetComponent<IMovable>();
        _iLook = GetComponent<ILook>();
        _playerInput.Player.Shoot.performed += ctx => _iShoot.Shoot();
        _playerHealth = GetComponent<PlayerHealth>();
    }

    public override void OnEnable()
    {
        if (!photonView.IsMine)
            return;
        _playerInput.Enable();
        _playerHealth.PlayerDeath += OnPlayerDeath;
    }

    public override void OnDisable()
    {
        if (!photonView.IsMine)
            return;
        _playerInput.Disable();
        _playerHealth.PlayerDeath -= OnPlayerDeath;
    }

    private void FixedUpdate()
    {
        if (!photonView.IsMine)
            return;
        _direction = _playerInput.Player.Move.ReadValue<Vector2>();
        _rotation = _playerInput.Player.Look.ReadValue<Vector2>();
        _iMovable.Move(_direction);
        Looking(_rotation);
    }

    private void Looking(Vector2 lookPosition)
    {
        if (lookPosition != Vector2.zero)
        {
            _iLook.Look(_rotation);
        }

    }

    private void OnPlayerDeath()
    {
        enabled = false;
    }
}
