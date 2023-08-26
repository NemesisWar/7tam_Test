using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersPool : MonoBehaviour
{
    private List<LobbyPlayerCell> _playerCell = new List<LobbyPlayerCell>();

    private void Awake()
    {
        _playerCell.AddRange(GetComponentsInChildren<LobbyPlayerCell>());
    }

    public void DisableSomeCells(int players)
    {
        for (int i = players; i < _playerCell.Count; i++)
        {
            _playerCell[i].gameObject.SetActive(false);
        }
    }

    public void FillCells(List<Photon.Realtime.Player> players)
    {
        for (int i = 0; i < players.Count; i++)
        {
            _playerCell[i].FillCell(players[i].NickName);
        }

    }
}
