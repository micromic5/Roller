using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnButtonRight : MonoBehaviour
{
    [SerializeField]
    public float speed = 10.0f;
    private bool moveRight = false;

    public GameObject player;

    void Update()
    {
        if (moveRight)
        {
            float translation = 0f;
            // Make it move 10 meters per second instead of 10 meters per frame...
            translation = speed * Time.deltaTime;

            // Move translation along the object's z-axis
            player.transform.Translate(translation, 0, 0);
        }
    }
    public void onPointerDownRaceButton()
    {
        moveRight = true;
    }

    public void onPointerUpRaceButton()
    {
        moveRight = false;
    }
}
