using UnityEngine;

[System.Serializable]
public class LevelSettings
{
    [SerializeField] private int _count;
    [SerializeField] private int _firstIndex;

    public int Count => _count;
    public int FirstIndex => _firstIndex;
}
