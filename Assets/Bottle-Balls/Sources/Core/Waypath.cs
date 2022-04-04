using UnityEngine;

public class Waypath : MonoBehaviour
{
    [SerializeField] private Transform[] _pathes;

    private int _currentIndexPath;

    public Transform NextPath()
    {
        if (_currentIndexPath >= _pathes.Length - 1)
            _currentIndexPath = 0;
        else
            _currentIndexPath++;

        return _pathes[_currentIndexPath];
    }
}