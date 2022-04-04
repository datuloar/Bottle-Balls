using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallsMultiplier : MonoBehaviour
{
    [SerializeField] private int _factor = 2;
    [SerializeField] private TMP_Text _factorLabel;
    [SerializeField] private BallsPool _pool;

    private List<IBall> _blackList = new List<IBall>();

    private void OnValidate()
    {
        _factorLabel.text = $"{_factor}X";
    }

    private void Multiply(IBall ball)
    {
        _blackList.Add(ball);

        for (int i = 0; i < _factor; i++)
        {
            var spawnedBall = _pool.Get(transform.position, ball.Color);
            _blackList.Add(spawnedBall);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IBall ball))
        {
            if (_blackList.Contains(ball))
                return;

            Multiply(ball);
        }
    }
}
