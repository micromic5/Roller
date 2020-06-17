using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShitTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "People")
        {
            other.GetComponent<HitByShitHandler>().fire();            
        }
        GameObject.Destroy(gameObject);
    }
}
