using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerSpawner : MonoBehaviourPunCallbacks
{
    private List<PlayerSpawnPoint> _spawnPosition = new List<PlayerSpawnPoint>();
    private List<Player> players = new List<Player>();

    private void Start()
    {
        _spawnPosition.AddRange(GetComponentsInChildren<PlayerSpawnPoint>());
        PhotonNetwork.Instantiate("Player", _spawnPosition[Random.Range(0, 4)].transform.position, Quaternion.identity);
    }



}
