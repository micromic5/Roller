﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Direction;
public class MoveStraight : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private Direction direction = Direction.FRONT;
    // Update is called once per frame
    void FixedUpdate()
    {
        float translation = Time.deltaTime * speed;

        switch (direction)
        {
            case LEFT:
                transform.Translate(-translation, 0, 0);
                break;
            case RIGHT:
                transform.Translate(translation, 0, 0);
                break;
            case FRONT:
                transform.Translate(0, 0, translation);
                break;
            case BACK:
                transform.Translate(0, 0, -translation);
                break;
            case UP:
                transform.Translate(0, translation, 0);
                break;
            case DOWN:
                transform.Translate(0, -translation, 0);
                break;
        }        
    }

    public float getSpeed()
    {
        return speed;
    }

    public void setSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public Direction getDirection()
    {
        return direction;
    }
}
