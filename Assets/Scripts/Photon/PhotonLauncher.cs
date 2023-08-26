using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonLauncher : MonoBehaviourPunCallbacks
{
    public bool IsConnected;
    [SerializeField] private GameObject _loadingPanel;
    [SerializeField] private CreateRoom _createRoom;
    [SerializeField] private GameObject _lobbyRoomPanel;
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private LobbyRoom _lobbyRoom;
    [SerializeField] private float _timeToReconnect;
    private Coroutine _coroutine;
    private string _gameVersion = "1";

    #region Methods
    private void Start()
    {
        TryConnectToPhoton();
    }

    public void TryConnectToPhoton()
    {
        _loadingPanel.SetActive(true);
        if (!PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.GameVersion = _gameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    private IEnumerator TryConnectAgain()
    {
        while (!PhotonNetwork.IsConnectedAndReady)
        {
            yield return new WaitForSeconds(_timeToReconnect);
            PhotonNetwork.ConnectUsingSettings();
        }
        StopCoroutine(_coroutine);
        _coroutine = null;
    }

    public void TryCreateRoom()
    {
        _loadingPanel.SetActive(true);
        _createRoom.gameObject.SetActive(false);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.CreateRoom(_createRoom.GetRoomName(), roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        _loadingPanel.SetActive(false);
        _lobbyRoomPanel.SetActive(true);
        _lobbyRoom.Init();
    }

    public void TryFindRoom()
    {
        PhotonNetwork.JoinLobby();
    }

    public void LoadGameLevel()
    {
        if(!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        PhotonNetwork.LoadLevel(1);
    }

    #endregion

    #region CallBacks
    public override void OnConnectedToMaster()
    {
        IsConnected = true;
        _loadingPanel.SetActive(false);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        IsConnected = false;
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(TryConnectAgain());
        }
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("ConnectionToLobby");
    }

    //public override void OnRoomListUpdate(List<RoomInfo> roomList)
    //{
    //    Debug.Log("OnRoomUpdate");
    //    if (_createdRoomList.isActiveAndEnabled)
    //    {
    //        _createdRoomList.CreatingRoomList(roomList);
    //    }
    //}

    public override void OnCreatedRoom()
    {
        Debug.Log("ROOM ON CREATED");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("ERROR");
        base.OnCreateRoomFailed(returnCode, message);
    }

    public void LeaveLobby()
    {
        PhotonNetwork.LeaveRoom();
        _mainPanel.SetActive(true);
    }



    #endregion
}
