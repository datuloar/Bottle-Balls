using UnityEngine;

[CreateAssetMenu(fileName = "New Game Settings", menuName = "Game / Settings", order = 51)]
public class GameSettings : ScriptableObject
{
    [SerializeField] private float _countdown;
    [SerializeField] private int _targetBottleCapacity;

    public float Countdown => _countdown;
    public int TargetBottleCapacity => _targetBottleCapacity;
}
