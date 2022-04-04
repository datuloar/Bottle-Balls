using TMPro;
using UnityEngine;

public class PlayWindow : MonoBehaviour, IPlayWindow
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private TMP_Text _ballsCountLabel;

    public void Close()
    {
        _canvasGroup.Close();
    }

    public void Open()
    {
        _canvasGroup.Open();
    }

    public void RenderBallsCount(int ballsCount, int capacity)
    {
        _ballsCountLabel.text = $"{ballsCount} / {capacity}";
    }
}
