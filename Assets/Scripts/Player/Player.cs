using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Photon.Pun;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(PlayerScore))]

public class Player : MonoBehaviourPunCallbacks, IMovable, IShoot,ILook
{

    public event UnityAction<float> OnHealthChange;
    [SerializeField] private float _speed;
    [SerializeField] private float _offset;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private CanvasPlayer _canvasPlayer;
    private PlayerScore _playerScore;
    private Rigidbody2D _rigidbody2D;
    private Vector2 looks;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerScore = GetComponent<PlayerScore>();
    }

    private void Start()
    {
        if (photonView.IsMine)
        {
            CanvasPlayer canvas = Instantiate(_canvasPlayer);
            canvas.Init(this);
        }
    }

    void IMovable.Move(Vector2 direction)
    {
        _rigidbody2D.velocity = direction*_speed;

    }

    void IShoot.Shoot()
    {
        PhotonNetwork.Instantiate("Bullet", _shootPoint.position, Quaternion.identity).GetComponent<Bullet>().Init(looks);
    }

    //void ILook.Look(Vector2 lookPosition)
    //{
    //    Vector2 look = (Vector2)Camera.main.ScreenToWorldPoint(lookPosition) - _rigidbody2D.position;
    //    look.Normalize();
    //    looks = look;
    //    //Debug.Log(look);
    //    var angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;
    //    _rigidbody2D.transform.rotation = Quaternion.Euler(0, 0, angle+_offset);
    //}

    void ILook.Look(Vector2 lookPosition)
    {
        if (lookPosition == Vector2.zero)
            return;
        lookPosition.Normalize();
        looks = lookPosition;
        //Debug.Log(look);
        var angle = Mathf.Atan2(looks.y, looks.x) * Mathf.Rad2Deg;
        _rigidbody2D.transform.rotation = Quaternion.Euler(0, 0, angle + _offset);
    }

}
