public class Game : IGame
{
    private readonly GameSettings _settings;
    private readonly Player _player;
    private readonly ITimer _timer;
    private readonly ILevel _level;
    private readonly IViewport _viewport;
    private readonly IBottle _bottle;
    private readonly IVisualEffects _visualEffects;
    private readonly IDataPersistence _dataPersistence;

    private bool _isPlaying;

    public Game(IViewport viewport, IInputCamera inputCamera,
        IBottle bottle, IVisualEffects visualEffects, ILevel level,
        IDataPersistence dataPersistence, GameSettings settings)
    {
        _viewport = viewport;
        _bottle = bottle;
        _settings = settings;
        _visualEffects = visualEffects;
        _dataPersistence = dataPersistence;
        _level = level;

        _player = new Player(inputCamera);
        _timer = new Timer();

        _bottle.CountChanged += OnBottleCountChanged;
        _timer.Completed += OnCountdownEnded;
        _viewport.GetVictoryWindow().NextButtonClicked += NextLevel;
        _viewport.GetDefeatWindow().RestartButtonClicked += Restart;
    }

    ~Game()
    {
        _bottle.CountChanged -= OnBottleCountChanged;
        _timer.Completed -= OnCountdownEnded;
        _viewport.GetVictoryWindow().NextButtonClicked -= NextLevel;
        _viewport.GetDefeatWindow().RestartButtonClicked -= Restart;
    }

    public void Start()
    {
        _viewport.GetPlayWindow().Open();
        _viewport.GetPlayWindow().
            RenderBallsCount(_bottle.BallsCount, _settings.TargetBottleCapacity);

        _player.EnableInput();

        _isPlaying = true;
    }

    public void Tick(float time)
    {
        if (_isPlaying)
        {
            _player.Tick(time);
            _timer.Tick(time);
        }
    }

    private void OnBottleCountChanged()
    {
        if (_isPlaying)
        {
            _viewport.GetPlayWindow()
                .RenderBallsCount(_bottle.BallsCount, _settings.TargetBottleCapacity);

            if (CheckExecutionTask())
                _visualEffects.GetVictoryEffect().PlayOnce();

            _timer.Start(_settings.Countdown);
        }
    }

    private void OnCountdownEnded()
    {
        if (CheckExecutionTask())
            _viewport.GetVictoryWindow().Open();
        else
            _viewport.GetDefeatWindow().Open();

        End();
    }

    private void End()
    {
        _isPlaying = false;

        _player.DisableInput();
    }

    private void NextLevel()
    {
        if (_level.HasNext)
        {
            _dataPersistence.Data.CurrentLevelIndex = _dataPersistence.Data.CurrentLevelIndex + 1;
            _dataPersistence.Save();
            _level.LoadNext();
        }
        else
        {
            _dataPersistence.Data.CurrentLevelIndex = _level.FirstLevelIndex;
            _dataPersistence.Save();
            _level.LoadFirst();
        }
    }

    private void Restart() => _level.Restart();

    private bool CheckExecutionTask() => _bottle.BallsCount >= _settings.TargetBottleCapacity;
}
