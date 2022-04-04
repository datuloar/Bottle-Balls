using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private string _saveKey;
    [SerializeField] private Viewport _viewport;
    [SerializeField] private InputCamera _inputCamera;
    [SerializeField] private Bottle _bottle;
    [SerializeField] private VisualEffects _visualEffects;

    [Header("Settings")]
    [SerializeField] private GameSettings _gameSettings;
    [SerializeField] private LevelSettings _levelSettings;

    private IGame _game;
    private IDataPersistence _dataPersistence;

    private void Awake()
    {
        var level = new Level(_levelSettings);

        _dataPersistence = new DataPersistence(_saveKey);

        _game = new Game(_viewport, _inputCamera, _bottle,
            _visualEffects, level, _dataPersistence, _gameSettings);
    }

    private void Start()
    {
        _game.Start();
    }

    private void Update()
    {
        _game.Tick(Time.deltaTime);
    }

    private void OnApplicationQuit()
    {
        _dataPersistence.Save();
    }
}
