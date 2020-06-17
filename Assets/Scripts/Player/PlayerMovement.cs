using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float speed = 10.0f;
    private Keyboard kb;
    private bool moveLeft = false;
    private bool moveRight = false;

    private void Start()
    {
        kb = InputSystem.GetDevice<Keyboard>();   
    }

    void Update()
    {
        float translation = 0f;
        if (kb.aKey.isPressed || moveLeft)
        {
            translation =  -speed;
        }else if (kb.dKey.isPressed || moveRight)
        {
            translation = speed;
        }
        
        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(translation, 0, 0);

        moveLeft = false;
        moveRight = false;
    }

    public void setMoveLeftTrue()
    {
        moveLeft = true;
    }

    public void setMoveRightTrue()
    {
        moveRight = true;
    }

}
