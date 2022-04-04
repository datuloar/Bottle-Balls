using UnityEngine;

public class VisualEffects : MonoBehaviour, IVisualEffects
{
    [SerializeField] private VictoryEffect _victoryEffect;

    public IVictoryEffect GetVictoryEffect() => _victoryEffect;
}
