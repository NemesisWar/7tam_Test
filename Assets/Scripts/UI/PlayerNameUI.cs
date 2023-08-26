using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameUI : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private PlayerData _playerData;

    private void Start()
    {
        _text.text = _playerData.PlayerName;
    }
}
