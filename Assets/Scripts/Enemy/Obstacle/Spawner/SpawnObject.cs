using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToSpawn;
    [SerializeField]
    private GameObject parentForSpawnedObject;
    [SerializeField]
    private float timeBetweenSpawn = 5f;
    [SerializeField]
    private float spawnTimer = 0f;
    [SerializeField]
    private float spawnTimeChanger = -0.1f;
    [SerializeField]
    private float spawnTimerRandomOffsetToZero = 0f;

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= 1 * Time.deltaTime;
        if (spawnTimer <= 0)
        {
            GameObject spawnedObject = Instantiate(objectToSpawn, parentForSpawnedObject.transform);
            spawnedObject.transform.position = gameObject.transform.position;
            spawnTimer = timeBetweenSpawn = (timeBetweenSpawn >= 0.5f)
                ? timeBetweenSpawn + spawnTimeChanger
                : timeBetweenSpawn + Random.Range(0, spawnTimerRandomOffsetToZero);
        }
    }
}
