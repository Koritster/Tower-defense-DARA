using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTurretSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] turretPrefabs;
    AudioSource building;

    private void Awake()
    {
        building = GameObject.FindGameObjectWithTag("Scripter").transform.GetChild(1).GetComponent<AudioSource>();
    }

    public void SpawnTurret()
    {
        if(Scripter.turretIndex != null)
        {
            int i = (int)Scripter.turretIndex;
            if (Scripter.money >= Scripter.pricesStatic[i])
            {
                Scripter.money -= Scripter.pricesStatic[i];
                Scripter.OnMoneyChange();
                Vector3 pos = new Vector3(transform.position.x, transform.position.y + turretPrefabs[i].GetComponent<Renderer>().bounds.size.y / 2, transform.position.z);
                building.Play();
                Instantiate(turretPrefabs[i], pos, Quaternion.identity);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("No tienes dinero suficiente " + Scripter.money);
            }

        }
        else
        {
            Debug.Log("No has seleccionado ninguna torre");
        }
    }
}
