using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomChildFromArray : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> prefabArray;

    void Start()
    {
        GameObject newChild = Instantiate(prefabArray[Random.RandomRange(0, prefabArray.Count)], gameObject.transform);
    }
}
