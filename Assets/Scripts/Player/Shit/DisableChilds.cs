using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableChilds : MonoBehaviour
{
    [SerializeField]
    private GameObject parent;
    [SerializeField]
    private float baseTimeTillDisable = 0f;
    private float timeTillDisable;
    

    void Start()
    {
        timeTillDisable = baseTimeTillDisable;
    }

    void OnEnable()
    {
        timeTillDisable = baseTimeTillDisable;
    }

    void Update()
    {
        timeTillDisable -= Time.deltaTime;
        if(timeTillDisable <= 0)
        {
            foreach (Transform child in parent.transform)
            {
                child.gameObject.SetActive(false);
                timeTillDisable = baseTimeTillDisable;
            }
        }
    }
}
