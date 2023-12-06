using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    public float speed = 70f;

    private Transform triggerBomb;
    private Transform target;

    private ParticleSystem particleBomb;

    public void Seek(Transform _target)
    {
        triggerBomb = transform.GetChild(0);
        target = _target;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    private void HitTarget()
    {
        triggerBomb.gameObject.SetActive(true);
        particleBomb.Play();
        
        Destroy(gameObject, 0.1f);
    }
}
