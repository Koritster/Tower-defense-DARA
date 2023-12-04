using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicle : MonoBehaviour
{
    public float speed = 70f;
    public int damage = 1;
    [Range(0f, 1f)]
    [Tooltip("Porcentaje de reducimiento de velocidad, ej. Para reducir la velocidad 20% colocar en este campo 0.20")]
    public float slownessEffect;
    [Tooltip("Tiempo que durará el efecto")]
    public float timeOfSlowness;

    private Transform target;

    public void Seek(Transform _target)
    {
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
        target.GetComponent<EnemyIA>().ReceiveDamage(damage);
        target.GetComponent<EnemyIA>().ChangeSpeed(slownessEffect, timeOfSlowness);
        Destroy(gameObject);
    }
}
