using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Touch myTouch;
    Camera camara;
    int layers;

    private void Awake()
    {
        camara = Camera.main;
        layers = LayerMask.GetMask("Torres", "Enemigos");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(camara.transform.position, camara.transform.forward * 10, Color.red);
    }

    private GameObject ObjectRaycast()
    {
        GameObject target = null;
        RaycastHit hit;

        if (Physics.Raycast(camara.transform.position, camara.transform.forward, out hit, Mathf.Infinity, layers))
        {
            target = hit.collider.gameObject;
        }

        return target;
    }

    #region Spawn Turrets && Damage Enemies

    public int weaponDamage;

    public void SpawnTurret()
    {
        GameObject t = ObjectRaycast();
        if (t.CompareTag("Tile"))
        {
            t.GetComponent<TileTurretSpawner>().SpawnTurret();
        }
    }

    public void DamageEnemy()
    {
        GameObject e = ObjectRaycast();
        if (e.CompareTag("Enemy"))
        {
            e.GetComponent<EnemyIA>().ReceiveDamage(weaponDamage);
        }
    }

    #endregion 
}
