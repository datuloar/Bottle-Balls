using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : ILevel
{
    private readonly LevelSettings _settings;

    public Level(LevelSettings settings)
    {
        _settings = settings;
    }

    public int CurrentSceneIndex => SceneManager.GetActiveScene().buildIndex;
    public int FirstLevelIndex => _settings.FirstIndex;

    public bool HasNext => CurrentSceneIndex <= _settings.Count;

    public void LoadNext()
    {
        if (HasNext)
            Load(CurrentSceneIndex + 1);
        else
            throw new ArgumentException("Сan't load next scene");
    }

    public void Restart() => Load(CurrentSceneIndex);

    public void LoadFirst() => Load(_settings.FirstIndex);

    public void Load(int index) => SceneManager.LoadScene(index);
}
