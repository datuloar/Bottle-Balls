using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallsPool : MonoBehaviour
{
    [SerializeField] private int _capacity = 15;
    [SerializeField] private int _additionCapacity = 15;
    [SerializeField] private Ball _template;
    [SerializeField] private Transform _spawnContainer;

    private List<Ball> _pool = new List<Ball>();

    private void OnValidate()
    {
        if (_capacity < 1)
            _capacity = 1;

        if (_additionCapacity < 1)
            _additionCapacity = 1;
    }

    private void Awake()
    {
        SpawnBalls(_capacity);
    }

    public IBall Get(Vector3 position, Color color)
    {
        Ball ball = _pool.FirstOrDefault(e => e.gameObject.activeSelf == false);

        if (ball != null)
        {
            ball.Show();
            ball.ChangeColor(color);
            ball.transform.position = position;

            return ball;
        }

         SpawnBalls(_additionCapacity);

         return Get(position, color);      
    }

    public void SpawnBalls(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Ball ball = Instantiate(_template, _spawnContainer);
            ball.Hide();

            _pool.Add(ball);
        }
    }
}
