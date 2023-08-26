using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Photon.Pun;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerHealth : MonoBehaviourPunCallbacks, IDamageble
{
    public event UnityAction<float> HealthChanged;
    public event UnityAction PlayerDeath;
    public float Health
    {
        get { return _health; }
        private set
        {
            _health = value;
            HealthChanged?.Invoke(_health);
            if (_health <= 0)
            {
                PlayerDeath?.Invoke();
                photonView.RPC("DeadSprite", RpcTarget.All);
                
            }
        }
    }
    [SerializeField] private float _health;
    [SerializeField] private Sprite _deathSprite;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void IDamageble.TakeDamage(float damage)
    {
        photonView.RPC("RPC_TakeGamage", RpcTarget.All, damage);
    }

    [PunRPC]
    private void DeadSprite()
    {
        _spriteRenderer.sprite = _deathSprite;
    }

    [PunRPC]
    void RPC_TakeGamage(float Damage)
    {
        if (!photonView.IsMine)
            return;

        Health -= Damage;
    }
}
