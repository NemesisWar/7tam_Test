using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerData : MonoBehaviour
{
    public string PlayerName
    {
        get { return _playerName; }
        private set { _playerName = value; }
    }
    private string _playerName;

    private void Start()
    {
        PlayerName = $"Player_{Random.Range(0, 1000)}";
        PhotonNetwork.NickName = PlayerName;
        PlayerPrefs.SetString("PlayerName", PlayerName);
    }
}
