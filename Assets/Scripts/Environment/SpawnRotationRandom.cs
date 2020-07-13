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

    void Start()
    {
        transform.rotation = Quaternion.Euler(xAxis ? randomFullRotation() : 0, yAxis ? randomFullRotation() : 0, zAxis ? randomFullRotation() : 0);
    }

    private float randomFullRotation()
    {
        return Random.Range(0, 360);
    }
}