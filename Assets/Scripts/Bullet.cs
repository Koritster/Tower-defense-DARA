using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 70f;
    public int damage = 1;

    private Transform target;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    private void HitTarget()
    {
        target.GetComponent<EnemyIA>().ReceiveDamage(damage);

        Destroy(gameObject);
    }
}
