using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private SplashEffectPool _pool;

    public void PlaySplashEffect(Vector3 position)
    {
        ParticleSystem splashEffect = _pool.Get(new Vector3(position.x, transform.position.y, position.z));
        splashEffect.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IBall ball))
        {
            PlaySplashEffect(ball.transform.position);

            ball.Hide();
        }
    }
}
