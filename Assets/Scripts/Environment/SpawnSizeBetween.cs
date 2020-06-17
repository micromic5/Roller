using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSizeBetween : MonoBehaviour
{
    [SerializeField]
    private float spawnSizeMin;
    [SerializeField]
    private float spwanSizeMax;

    void Start()
    {
        float scaleSize = Random.RandomRange(spawnSizeMin, spwanSizeMax);
        transform.localScale = new Vector3(scaleSize, scaleSize, scaleSize);
    }
}
