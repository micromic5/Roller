﻿using System.Collections;
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
    private float spawnTimeChanger = 0f;
    [SerializeField]
    private float spawnTimeChangeMin = 0f;
    [SerializeField]
    private float spawnTimeChangeMax = 0f;
    [SerializeField]
    private float randomSpawnOffsetMin = 0;
    [SerializeField]
    private float randomSpawnOffsetMax = 0;
    private ChangeSpeed changeSpeedScript;

    private void Start()
    {
        changeSpeedScript = GetComponent<ChangeSpeed>();
    }
    // Update is called once per frame
    void Update()
    {
        spawnTimer -= 1 * Time.deltaTime;
        if (spawnTimer <= 0)
        {
            GameObject spawnedObject = Instantiate(objectToSpawn, parentForSpawnedObject.transform);
            spawnedObject.transform.position = gameObject.transform.position;
            if(changeSpeedScript != null)
            {
                spawnedObject.GetComponent<MoveStraight>().setSpeed(spawnedObject.GetComponent<MoveStraight>().getSpeed() + changeSpeedScript.getCurrentSpeed());
            }
            if(spawnTimeChanger != 0)
            {
                timeBetweenSpawn += calculateSpawnTimeChange();
            }
            Debug.Log("calcMin: "+calculateMinSpawnOffset());
            Debug.Log("offsetmax: " + randomSpawnOffsetMax);
            spawnTimer = timeBetweenSpawn + Random.Range(calculateMinSpawnOffset(), randomSpawnOffsetMax);
        }
    }

    private float calculateMinSpawnOffset()
    {
        return randomSpawnOffsetMin + timeBetweenSpawn <= spawnTimeChangeMin ? spawnTimeChangeMin : randomSpawnOffsetMin;
    }

    private float calculateSpawnTimeChange()
    {
        return (timeBetweenSpawn >= spawnTimeChangeMin && timeBetweenSpawn <= spawnTimeChangeMax) ? spawnTimeChanger : 0;
    }
}
