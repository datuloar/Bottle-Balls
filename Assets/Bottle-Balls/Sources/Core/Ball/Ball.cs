using UnityEngine;

public class Ball : MonoBehaviour, IBall
{
    [SerializeField] private Color _color;
    [SerializeField] private MeshRenderer _meshRenderer;

    public Color Color => _color;
    public bool CanMultiple { get; set; } = true;

    private void OnValidate()
    {
        ChangeColor(_color);
    }

    public void ChangeColor(Color color) =>
        _meshRenderer.SetProperty("_Color", color);

    public void Show() => gameObject.SetActive(true);

    public void Hide() => gameObject.SetActive(false);
}
