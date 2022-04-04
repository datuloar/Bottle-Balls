using System;
using System.Collections.Generic;
using UnityEngine;

public class Trigger<T> : MonoBehaviour
{
    [SerializeField] private Collider _collider;

    private List<T> _enteredObjects = new List<T>();

    public IReadOnlyList<T> EnteredObjects => _enteredObjects;

    public event Action<T> Entered;
    public event Action<T> Stay;
    public event Action<T> Exit;

    public void Disable() => _collider.enabled = false;

    public void Enable() => _collider.enabled = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out T triggered))
        {
            _enteredObjects.Add(triggered);
            Entered?.Invoke(triggered);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out T triggered))
        {
            Stay?.Invoke(triggered);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out T triggeredObject))
        {
            _enteredObjects.Remove(triggeredObject);
            Exit?.Invoke(triggeredObject);
        }
    }
}