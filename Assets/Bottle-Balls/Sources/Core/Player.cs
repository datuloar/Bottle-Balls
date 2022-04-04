using UnityEngine;

public class Player : IUpdateLoop
{
    private readonly IInputCamera _inputCamera;

    private bool _inputWork;

    public Player(IInputCamera inputCamera)
    {
        _inputCamera = inputCamera;
    }

    public void Tick(float time)
    {
        if (Input.GetMouseButtonDown(0) && _inputWork)
        {
            Ray ray = _inputCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out IBallPusher wall))
                {
                    wall.Push();
                }
            }
        }
    }

    public void DisableInput() => _inputWork = false;

    public void EnableInput() => _inputWork = true;
}
