﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpeed : MonoBehaviour
{
    [SerializeField]
    private float baseTimeBetweenSpeedChanges;
    private float timeBetweenSpeedChanges;
    [SerializeField]
    private float amountOfSpeedChange = 0.01f;
    [SerializeField]
    private float maxSpeed = 10f;
    [SerializeField]
    private float currentSpeed = 0;

    void Start()
    {
        timeBetweenSpeedChanges = baseTimeBetweenSpeedChanges;
    }
    void Update()
    {
        if(currentSpeed <= maxSpeed)
        {
            timeBetweenSpeedChanges -= Time.deltaTime;
            if (timeBetweenSpeedChanges <= 0)
            {
                currentSpeed += amountOfSpeedChange;
                timeBetweenSpeedChanges = baseTimeBetweenSpeedChanges;
            }
        }
        else
        {
            enabled = false;
        }
    }

    public float getCurrentSpeed()
    {
        return currentSpeed;
    }

    public float getAamountOfSpeedChange() {
        return amountOfSpeedChange;
    }

    public float getBaseTimeBetweenSpeedChanges()
    {
        return baseTimeBetweenSpeedChanges;
    }

    public void setCurrentSpeed(float speed)
    {
        currentSpeed = speed + currentSpeed > maxSpeed ? maxSpeed : speed + currentSpeed;
    }
}
