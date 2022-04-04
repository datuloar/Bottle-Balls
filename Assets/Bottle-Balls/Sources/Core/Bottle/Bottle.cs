using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bottle : MonoBehaviour, IBottle
{
    [SerializeField] private TMP_Text _ballsCountLabel;
    [SerializeField] private BottleTrigger _trigger;

    private List<IBall> _balls = new List<IBall>();

    public int BallsCount => _balls.Count;

    public event Action CountChanged;

    private void OnEnable()
    {
        _trigger.Entered += OnEntered;
    }

    private void OnDisable()
    {
        _trigger.Entered -= OnEntered;
    }

    private void OnEntered(IBall ball)
    {
        if (_balls.Contains(ball)) 
            return;

        _balls.Add(ball);

        CountChanged?.Invoke();
    }
}
