using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Yielder
{
    private static Dictionary<float, WaitForSeconds> _timeInterval = new Dictionary<float, WaitForSeconds>(100);
    private static WaitForEndOfFrame _endOfFrame = new WaitForEndOfFrame();
    private static WaitForFixedUpdate _fixedUpdate = new WaitForFixedUpdate();

    public static WaitForEndOfFrame EndOfFrame => _endOfFrame;

    public static WaitForFixedUpdate FixedUpdate => _fixedUpdate;

    public static WaitForSeconds WaitForSeconds(float seconds)
    {
        if (!_timeInterval.ContainsKey(seconds))
            _timeInterval.Add(seconds, new WaitForSeconds(seconds));

        return _timeInterval[seconds];
    }
}