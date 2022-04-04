using UnityEngine;

public static class TransformExtensions
{
    public static void LookAtXZ(this Transform transform, Vector3 point)
    {
        var direction = (point - transform.position).normalized;
        direction.y = 0f;
        transform.rotation = Quaternion.LookRotation(direction);
    }

    public static void LookAtXZ(this Transform transform, Vector3 point, float speed)
    {
        var direction = (point - transform.position).normalized;
        direction.y = 0f;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), speed);
    }
}
