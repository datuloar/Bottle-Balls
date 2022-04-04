using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ParticlesPool : MonoBehaviour
{
    [SerializeField] private int _capacity = 15;
    [SerializeField] private int _additionCapacity = 15;
    [SerializeField] private ParticleSystem _template;
    [SerializeField] private Transform _spawnContainer;

    private List<ParticleSystem> _pool = new List<ParticleSystem>();

    private void OnValidate()
    {
        if (_capacity < 1)
            _capacity = 1;

        if (_additionCapacity < 1)
            _additionCapacity = 1;
    }

    private void Awake()
    {
        SpawnParticles(_capacity);
    }

    public ParticleSystem Get(Vector3 position)
    {
        ParticleSystem particle = _pool.FirstOrDefault(e => e.gameObject.activeSelf == false);

        if (particle != null)
        {
            particle.transform.position = position;
            particle.gameObject.SetActive(true);

            return particle;
        }

        SpawnParticles(_additionCapacity);

        return Get(position);
    }

    public void SpawnParticles(int count)
    {
        for (int i = 0; i < count; i++)
        {
            ParticleSystem particle = Instantiate(_template, _spawnContainer);
            particle.gameObject.SetActive(false);

            _pool.Add(particle);
        }
    }
}
