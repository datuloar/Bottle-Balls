using System;

public interface IBottle
{
    int BallsCount { get; }

    event Action CountChanged;
}
