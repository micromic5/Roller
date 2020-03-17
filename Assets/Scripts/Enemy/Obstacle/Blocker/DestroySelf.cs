using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    [SerializeField]
    private float selfDestructionTime = 5f;

    // Update is called once per frame
    void Update()
    {
        selfDestructionTime -= 1 * Time.deltaTime;
        if (selfDestructionTime <= 0)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
