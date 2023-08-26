using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.Linq;
using UnityEngine.UI;

public class LobbyRoom : MonoBehaviourPunCallbacks
{
    [SerializeField] private Text _roomNameText;
    private PlayersPool _playersPool;
    private List<Photon.Realtime.Player> _players = new List<Photon.Realtime.Player>();

    private void Awake()
    {
        _playersPool = GetComponentInChildren<PlayersPool>();
    }

    public void Init()
    {
        SetLimitCells();
        Refresh();
        SetRoomName();
    }

    private void SetRoomName()
    {
        _roomNameText.text = PhotonNetwork.CurrentRoom.Name;
    }

    private void SetLimitCells()
    {
        _playersPool.DisableSomeCells(PhotonNetwork.CurrentRoom.MaxPlayers);
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        Debug.Log("Entered");
        Refresh();
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        Debug.Log(otherPlayer.NickName + "Покинкул комнату");
        Refresh();
    }

    private void Refresh()
    {
        Debug.Log(PhotonNetwork.PlayerList.Length);
        _players = PhotonNetwork.PlayerList.ToList();
        _playersPool.FillCells(_players);
    }
}
