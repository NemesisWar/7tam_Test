using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Coin : MonoBehaviourPunCallbacks
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out PlayerScore playerScore))
        {
            playerScore.AddScore();
            photonView.RPC("Destroy", RpcTarget.All);
            //PhotonNetwork.Destroy(gameObject);
        }
    }

    [PunRPC]
    public void Destroy()
    {
        PhotonNetwork.Destroy(gameObject);
    }
}
