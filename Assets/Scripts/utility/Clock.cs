using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public float timeFromStart = 0f;
    
    // Update is called once per frame
    void Update()
    {
        timeFromStart += Time.deltaTime;
    }
}
