using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToMeshFromArray : MonoBehaviour
{
    [SerializeField]
    private List<Mesh> meshArray;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshFilter>().mesh = meshArray[Random.RandomRange(0, meshArray.Count - 1)];
            
    }
}
