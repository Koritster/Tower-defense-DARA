using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTurretSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] turretPrefabs;

    public void SpawnTurret()
    {
        if(Scripter.turretIndex != null)
        {
            int i = (int)Scripter.turretIndex;
            Vector3 pos = new Vector3(transform.position.x, transform.position.y + turretPrefabs[i].GetComponent<Renderer>().bounds.size.y / 2, transform.position.z);

            Instantiate(turretPrefabs[i], pos, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("No has seleccionado ninguna torre");
        }
    }
}
