using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GamePlayProcess : MonoBehaviourPunCallbacks
{
    private List<Photon.Realtime.Player> players = new List<Photon.Realtime.Player>();

    private void Start()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        players.AddRange(PhotonNetwork.PlayerList);
    }

    private void EndGame()
    {
        foreach(Photon.Realtime.Player p in players)
        {
            if (p.IsInactive == false)
            {
                Debug.Log("GAMEOVER");
            }
        }
    }
}
