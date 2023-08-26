using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerScore : MonoBehaviour
{
    public event UnityAction<int> ScoreChanged;
    [SerializeField]private int _score;


    public void AddScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }
}
