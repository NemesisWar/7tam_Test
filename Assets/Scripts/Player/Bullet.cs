using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(CircleCollider2D))]
public class Bullet : MonoBehaviourPunCallbacks
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;
    private Vector2 _direction;

    private void Update()
    {
        transform.position += (Vector3)_direction * _speed * Time.deltaTime;
    }

    public void Init(Vector2 direction)
    {
        _direction = direction;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageble damagable))
        {
            damagable.TakeDamage(_damage);
            PhotonNetwork.Destroy(gameObject);

        }

        else
        {
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
