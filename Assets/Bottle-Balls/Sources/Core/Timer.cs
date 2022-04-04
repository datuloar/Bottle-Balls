using System;

public class Timer : ITimer
{
    private bool _isStarted;

    public float Time { get; private set; }
    public float ElapsedTime { get; private set; }

    public event Action Completed;

    public void Tick(float tick)
    {
        if (_isStarted == false)
            return;

        ElapsedTime += tick;

        if (ElapsedTime >= Time)
        {
            _isStarted = false;
            Completed?.Invoke();
        }
    }

    public void Start(float time)
    {
        ElapsedTime = 0;
        Time = time;
        _isStarted = true;
    }

    public void Stop() => _isStarted = false;
}
