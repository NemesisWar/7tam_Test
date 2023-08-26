using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasPlayer : MonoBehaviour
{
    public Player Player;

    public void Init(Player player)
    {
        Player = player;
        gameObject.SetActive(true);
    }
}
