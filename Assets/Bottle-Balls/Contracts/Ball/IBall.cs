using UnityEngine;

public interface IBall
{
    Color Color { get; }
    Transform transform { get; }

    void ChangeColor(Color color);
    void Hide();
    void Show();
}
