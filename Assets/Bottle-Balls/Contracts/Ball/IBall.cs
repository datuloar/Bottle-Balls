using UnityEngine;

public interface IBall
{
    Color Color { get; }
    bool CanMultiple { get; set; }
    Transform transform { get; }

    void ChangeColor(Color color);
    void Hide();
    void Show();
}
