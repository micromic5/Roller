using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabRandomProperties : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabToSpawn;
    [SerializeField]
    private int amountOfPrefabsToSpawn;
    [SerializeField]
    private float randomDisplacementMin;
    [SerializeField]
    private float randomDisplacementMax;
    [SerializeField]
    private float randomSizeMin;
    [SerializeField]
    private float randomSizeMax;
    [SerializeField]
    private float randomRotationMin;
    [SerializeField]
    private float randomRotationMax;
    void Start()
    {
        for(int i = 0; i < amountOfPrefabsToSpawn; i++)
        {
            GameObject randomizedPrefab = Instantiate(prefabToSpawn, this.transform);
            Vector3 oldPosition = randomizedPrefab.transform.position;
            randomizedPrefab.transform.position = new Vector3(
                oldPosition.x + Random.Range(randomDisplacementMin, randomDisplacementMax),
                oldPosition.y + Random.Range(randomDisplacementMin, randomDisplacementMax),
                oldPosition.z + Random.Range(randomDisplacementMin, randomDisplacementMax));
            float randomSize = Random.Range(randomSizeMin, randomSizeMax);
            randomizedPrefab.transform.localScale = new Vector3(randomSize, randomSize, randomSize);
            randomizedPrefab.transform.Rotate(
                Random.Range(randomRotationMin, randomRotationMax),
                Random.Range(randomRotationMin, randomRotationMax),
                Random.Range(randomRotationMin, randomRotationMax));
        }
    }
}
