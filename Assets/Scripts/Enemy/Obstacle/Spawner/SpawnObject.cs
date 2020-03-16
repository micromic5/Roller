using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField]
    private GameObject obstacle;
    [SerializeField]
    private GameObject parentForObstacles;
    [SerializeField]
    private float timeBetweenSpawn = 5f;
    private float spawnTimer = 5f;

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= 1 * Time.deltaTime;
        if (spawnTimer <= 0)
        {
            GameObject spawnedObject = Instantiate(obstacle, parentForObstacles.transform);
            spawnedObject.transform.position = gameObject.transform.position;
            spawnTimer = timeBetweenSpawn = (timeBetweenSpawn >= 0.5f)
                ? timeBetweenSpawn - 0.1f
                : timeBetweenSpawn;
        }
    }
}
