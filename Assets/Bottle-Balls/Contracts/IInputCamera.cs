using UnityEngine;

public interface IInputCamera
{
    Ray ScreenPointToRay(Vector3 position);
}
