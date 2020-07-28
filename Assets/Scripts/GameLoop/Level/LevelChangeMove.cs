using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChangeMove : MonoBehaviour
{
    void Start()
    {
        if(Level.getLevel() == 3)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 70);
        }
    }
}
