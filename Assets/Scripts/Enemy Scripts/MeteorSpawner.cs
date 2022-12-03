using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] meteors;

    [SerializeField] private float minX, maxX;

    [SerializeField] private float minSpawnInterwal = 5f, maxSpawnInterval = 10f;

    private int randSpawnNum;

    private Vector3 randSpawnPos;

    private void Start()
    {
        Invoke("SpawnMeteors", Random.Range(minSpawnInterwal, maxSpawnInterval));
    }

    void SpawnMeteors()
    {
        randSpawnNum = Random.Range(0, meteors.Length);

        for (int i = 0; i < randSpawnNum; i++)
        {
            randSpawnPos = new Vector3(Random.Range(minX, maxX), transform.position.y, 0f);
            Instantiate(meteors[Random.Range(0, meteors.Length)], randSpawnPos, Quaternion.identity);
        }

        Invoke("SpawnMeteors", Random.Range(minSpawnInterwal, maxSpawnInterval));
    }
}
