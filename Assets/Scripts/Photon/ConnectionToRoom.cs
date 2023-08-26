using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class ConnectionToRoom : MonoBehaviourPunCallbacks
{
    [SerializeField] private InputField _inputField;
    private string _roomName;

    private void Start()
    {
        _inputField = GetComponentInChildren<InputField>();
        _inputField.onValueChanged.AddListener(RoomNameChanged);
    }

    private void RoomNameChanged(string roomName)
    {
        _roomName = roomName;
    }

    public void ConnectToRoom()
    {
        PhotonNetwork.JoinRoom(_roomName);
        gameObject.SetActive(false);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        base.OnRoomListUpdate(roomList);
    }
}
