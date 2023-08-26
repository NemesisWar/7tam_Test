using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Photon.Pun;

public class CoinSpawner : MonoBehaviourPunCallbacks
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private int _countCoins;
    [SerializeField] private Coin _coin;
    private List<Vector3Int> _groundVectors = new List<Vector3Int>();

    private void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            GetPositionsTiles();
            Spawn();
        }
    }

    private void GetPositionsTiles()
    {
        foreach (var position in tilemap.cellBounds.allPositionsWithin)
        {
            if (!tilemap.HasTile(position))
            {
                continue;
            }
            _groundVectors.Add(position);
        }
    }

    private void Spawn()
    {
        for (int i = 0; i < _countCoins; i++)
        {
            int tileNumber = Random.Range(0, _groundVectors.Count);
            PhotonNetwork.Instantiate(_coin.gameObject.name, _groundVectors[tileNumber], Quaternion.identity).transform.SetParent(transform,false);
            _groundVectors.RemoveAt(tileNumber);
        }
    }
}
