using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTranslationRandom : MonoBehaviour
{

    [SerializeField]
    bool xAxis = false;
    [SerializeField]
    bool yAxis = false;
    [SerializeField]
    bool zAxis = false;
    [SerializeField]
    float offset = 0;
    void Start()
    {
        transform.Translate( 
            new Vector3(xAxis ? randomValueBetween() : 0, yAxis ? randomValueBetween() : 0, zAxis ? randomValueBetween() : 0));
    }

    private float randomValueBetween()
    {
        return Random.Range(-offset, offset);
    }
}
