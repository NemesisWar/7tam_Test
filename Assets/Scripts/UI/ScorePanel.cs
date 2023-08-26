using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePanel : MonoBehaviour
{
    private Text _scoreText;
    private CanvasPlayer _canvasPlayer;

    private void Awake()
    {
        _scoreText = GetComponentInChildren<Text>();
        _canvasPlayer = GetComponentInParent<CanvasPlayer>();
    }
    private void OnEnable()
    {
        _canvasPlayer.Player.GetComponent<PlayerScore>().ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _canvasPlayer.Player.GetComponent<PlayerScore>().ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _scoreText.text = score.ToString();
    }

}
