using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPusher : MonoBehaviour, IBallPusher
{
    [SerializeField] private BallPushersBrain _brain;
    [SerializeField] private BallPusherMovement _movement;
    [SerializeField] private DirectionPointer _pointer;

    public bool IsPushing { get; private set; }

    public void Push()
    {
        if (_brain.CanMove())
        {
            IsPushing = true;
            _movement.StartMove(OnMoveEnded);
        }
    }

    private void OnMoveEnded()
    {
        IsPushing = false;
        _pointer.Switch();
    }
}
