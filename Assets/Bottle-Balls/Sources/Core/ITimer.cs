using System;

public interface ITimer : IUpdateLoop
{
    float Time { get; }
    float ElapsedTime { get; }

    event Action Completed;

    void Start(float time);
    void Stop();
}
