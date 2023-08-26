using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HelthBarUI : MonoBehaviour
{
    private Slider _slider;
    private CanvasPlayer _canvasPlayer;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _canvasPlayer = GetComponentInParent<CanvasPlayer>();
    }
    private void OnEnable()
    {
        _canvasPlayer.Player.GetComponent<PlayerHealth>().HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _canvasPlayer.Player.GetComponent<PlayerHealth>().HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float health)
    {
        _slider.value = health/100;
    }
}
