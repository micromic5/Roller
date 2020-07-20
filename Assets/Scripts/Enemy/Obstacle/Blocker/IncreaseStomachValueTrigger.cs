using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseStomachValueTrigger : MonoBehaviour
{
    [SerializeField]
    private int increaseValueAmount = 10;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerData>().getStomach().increaseStomachValue(increaseValueAmount);
            Destroy(gameObject);
        }
    }
}
