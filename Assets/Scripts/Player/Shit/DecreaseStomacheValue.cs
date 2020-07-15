using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseStomacheValue : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private int decreaseAmount = 5;
    private Stomach stomach;
    private float timeBetweenDecreaseCalls = .5f;
    private float baseTimeBetweenDecreaseCalls = .5f;


    private void Start()
    {
        stomach = player.GetComponent<PlayerData>().getStomach();
    }
    void Update()
    {
        timeBetweenDecreaseCalls -= Time.deltaTime;
        if (timeBetweenDecreaseCalls <= 0)
        {
            stomach.decreaseStomachValue(decreaseAmount);
            timeBetweenDecreaseCalls = baseTimeBetweenDecreaseCalls;
        }
    }
}
