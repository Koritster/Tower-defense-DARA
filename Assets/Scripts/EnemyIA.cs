using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    [Range(1, 10)]
    public float speed;

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

    #endregion

    #region Waypoints

    private int wavepointIndex = 0;

    private void NextWaypoint()
    {
        if (wavepointIndex >= Waypoints.waypoints.Length - 1)
        {
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
    
    public void ReceiveDamage(int damagePoints)
    {
        health -= damagePoints;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    #endregion
}
