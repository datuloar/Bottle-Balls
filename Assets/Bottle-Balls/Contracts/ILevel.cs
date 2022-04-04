public interface ILevel
{
    int CurrentSceneIndex { get; }
    bool HasNext { get; }
    int FirstLevelIndex { get; }

    void Load(int index);
    void LoadFirst();
    void LoadNext();
    void Restart();
}