using System;

public interface IDefeatWindow : IWindow
{
    event Action RestartButtonClicked;
}
