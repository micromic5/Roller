using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnButtonLeft : MonoBehaviour
{
    [SerializeField]
    public float speed = 10.0f;
    private bool moveLeft = false;
   
    public GameObject player;

    void Update()
    {
        if (moveLeft)
        {
             float translation = 0f;
            // Make it move 10 meters per second instead of 10 meters per frame...
            translation = -speed * Time.deltaTime;

            // Move translation along the object's z-axis
            player.transform.Translate(translation, 0, 0);
        }
    }
    public void onPointerDownRaceButton()
    {
        moveLeft = true;
    }

    public void onPointerUpRaceButton()
    {
        moveLeft = false;
    }
}
