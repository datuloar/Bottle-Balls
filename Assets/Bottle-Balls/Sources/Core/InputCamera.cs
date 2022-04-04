using UnityEngine;

[RequireComponent(typeof(Camera))]
public class InputCamera : MonoBehaviour, IInputCamera
{
    [SerializeField] private Camera _camera;

    public Ray ScreenPointToRay(Vector3 position) =>
        _camera.ScreenPointToRay(position);
}
