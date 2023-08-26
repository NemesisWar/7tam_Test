using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyPlayerCell : MonoBehaviour
{
    public bool CellIsFill;
    [SerializeField] private Text _playerName;

    public void FillCell(string player)
    {
        _playerName.text = player;
        CellIsFill = true;
    }

    public void ClearCell()
    {
        _playerName.text = "";
        CellIsFill = false;
    }
}
