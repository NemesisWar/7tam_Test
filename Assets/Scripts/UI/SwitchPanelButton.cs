using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SwitchPanelButton : MonoBehaviour
{
    [SerializeField] private GameObject _disablePanel;
    [SerializeField] private GameObject _enablePanel;
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SwitchPanel);
    }

    private void SwitchPanel()
    {
        _disablePanel.SetActive(false);
        _enablePanel.SetActive(true);
    }

}
