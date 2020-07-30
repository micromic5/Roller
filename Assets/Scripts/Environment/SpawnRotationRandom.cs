using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRotationRandom : MonoBehaviour
{
    [SerializeField]
    bool xAxis = false;
    [SerializeField]
    bool yAxis = false;
    [SerializeField]
    bool zAxis = false;
    [SerializeField]
    int[] possibleRotationAngles;

    void Start()
    {
        transform.rotation = Quaternion.Euler(xAxis ? randomRotation() : 0, yAxis ? randomRotation() : 0, zAxis ? randomRotation() : 0);
    }

    private float randomRotation()
    {
        return possibleRotationAngles.Length > 0 ? randomFromPossibleRotationAngles() : randomFullRotation();
    }

    private float randomFullRotation()
    {
        return Random.Range(0, 360);
    }

    private float randomFromPossibleRotationAngles()
    {
        return possibleRotationAngles[Random.Range(0,possibleRotationAngles.Length - 1)];
    }
}