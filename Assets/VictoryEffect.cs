using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryEffect : MonoBehaviour, IVictoryEffect
{
    [SerializeField] private List<ParticleSystem> _particles;

    private bool _isPlaying;

    public void PlayOnce()
    {
        if (_isPlaying)
            return;

        foreach (var particle in _particles)
            particle.Play();

        _isPlaying = true;
    }
}
