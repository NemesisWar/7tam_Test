using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CreateRoom : MonoBehaviour
{
    private InputField _inputField;
    private string _roomName;

    private void Awake()
    {
        _inputField = GetComponentInChildren<InputField>();
        _inputField.onValueChanged.AddListener(ChangeRoomName);
    }

    private void ChangeRoomName(string name)
    {
        _roomName = name;
    }

    public string GetRoomName()
    {
        if (string.IsNullOrEmpty(_roomName))
        {
            _roomName = PhotonNetwork.NickName;
        }
        return _roomName;
    }
}
