using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToMeshFromArray : MonoBehaviour
{
    [SerializeField]
    private List<Mesh> meshArray;

    void Start()
    {
        GetComponent<MeshFilter>().mesh = meshArray[Random.RandomRange(0, meshArray.Count)];
    }
}
