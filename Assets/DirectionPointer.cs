using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionPointer : MonoBehaviour
{
    [SerializeField] private GameObject _pointerBack;
    [SerializeField] private GameObject _pointerForward;

    public void Switch()
    {
        if (_pointerBack.activeSelf)
        {
            _pointerBack.SetActive(false);
            _pointerForward.SetActive(true);
        }
        else
        {
            _pointerBack.SetActive(true);
            _pointerForward.SetActive(false);
        }
    }
}
