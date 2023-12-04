using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    [Range(1, 10)]
    public float normalSpeed, speed;

    private Rigidbody rb;
    private Transform target;


    void Awake()
    {
        Debug.Log("Enemy spawned");

        Physics.IgnoreLayerCollision(this.gameObject.layer, this.gameObject.layer);

        //GetComponents
        rb = GetComponent<Rigidbody>();

        //Waypoints
        target = Waypoints.waypoints[0];

        Debug.Log(Vector3.Distance(transform.position, target.position));
    }

    #region Movement

    private void FixedUpdate()
    {
        Movement();
    }

    Vector3 dir;

    private void Movement()
    {
        //Move Caracter
        dir = target.position - transform.position;
        rb.MovePosition(transform.position + dir.normalized * speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            NextWaypoint();
        }
    }

    public void ChangeSpeed(float multiplicador, float timeOfSlowness)
    {
        speed *= 1 - multiplicador;
        StartCoroutine(Slowness(timeOfSlowness));
    }

    IEnumerator Slowness(float timeOfSlowness)
    {
        yield return new WaitForSeconds(timeOfSlowness);
        speed = normalSpeed;
    }

    #endregion

    #region Waypoints

    private int wavepointIndex = 0;
    public int damage;

    private void NextWaypoint()
    {
        if (wavepointIndex >= Waypoints.waypoints.Length - 1)
        {
            Scripter.PlayerReceiveDamage(damage);
            Destroy(gameObject);
        }
        else
        {
            wavepointIndex++;
            target = Waypoints.waypoints[wavepointIndex];
        }

    }

    #endregion

    #region Vida

    [Header("Vida")]
    public int health;
    [Tooltip("Primer parametro - Dinero minimo a dropear. Segundo parametro - Dinero maximo a dropear.")]
    public Vector2 moneyDying;
    
    public void ReceiveDamage(int damagePoints)
    {
        health -= damagePoints;
        if (health <= 0)
        {
            Scripter.money += Random.Range((int)moneyDying.x, ((int)moneyDying.y + 1));
            Scripter.OnMoneyChange();
            Destroy(gameObject);
        }
    }

    #endregion
}
