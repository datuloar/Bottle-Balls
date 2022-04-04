using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallPushersBrain : MonoBehaviour
{
    [SerializeField] private List<BallPusher> _ballPushers;

    private void OnValidate()
    {
        _ballPushers = GetComponentsInChildren<BallPusher>()
            .ToList();
    }

    public bool CanMove()
    {
        foreach (var ballPusher in _ballPushers)
        {
            if (ballPusher.IsPushing)
                return false;
        }

        return true;
    }
}
