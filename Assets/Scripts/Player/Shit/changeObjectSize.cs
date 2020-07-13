using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeObjectSize : MonoBehaviour
{
    //[SerializeField]
    private float startSize = 0;
    [SerializeField]
    private float endSize;
    private float sizeChangeSpeed = 80f;
    void Start()
    {
        transform.localScale = new Vector3(startSize, startSize, startSize);

    }
    
    void Update()
    {
        if(transform.localScale.x > endSize)
        {
            GetComponent<changeObjectSize>().enabled = false;
        }
        transform.localScale = new Vector3(
            transform.localScale.x + sizeChangeSpeed*Time.deltaTime, 
            transform.localScale.y + sizeChangeSpeed * Time.deltaTime, 
            transform.localScale.z + sizeChangeSpeed * Time.deltaTime);
    }
}
