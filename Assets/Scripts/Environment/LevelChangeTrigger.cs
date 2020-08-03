using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChangeTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("Leve2").GetComponent<LevelChangeMove>().moveLevel();
        }        
    }
}
