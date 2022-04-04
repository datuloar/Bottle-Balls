using System;
using UnityEngine;
using UnityEngine.UI;

public class VictoryWindow : MonoBehaviour, IVictoryWindow
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Button _nextButton;

    public event Action NextButtonClicked;

    private void OnEnable()
    {
        _nextButton.onClick.AddListener(OnNextButtonClicked);
    }

    private void OnDisable()
    {
        _nextButton.onClick.RemoveListener(OnNextButtonClicked);
    }

    public void Close()
    {
        _canvasGroup.Close();
    }

    public void Open()
    {
        _canvasGroup.Open();
    }

    private void OnNextButtonClicked()
    {
        NextButtonClicked?.Invoke();
    }
}
