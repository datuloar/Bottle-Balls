using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPusherMovement : MonoBehaviour
{
    [SerializeField] private Waypath _waypath;
    [SerializeField] private float _moveSpeed;

    private Coroutine _moving;

    public void StartMove(Action Ended)
    {
        if (_moving != null)
            StopCoroutine(_moving);

        _moving = StartCoroutine(Moving(_waypath.NextPath(), Ended));
    }

    private IEnumerator Moving(Transform target, Action Ended)
    {
        while (transform.position != target.position)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                target.position, _moveSpeed * Time.deltaTime);

            yield return null;
        }

        Ended?.Invoke();
    }
}
