using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float speed = 10.0f;
    private float rotationSpeed = 5f;
    private bool rotationDirectionLeft = true;
    private Keyboard kb;
    private bool moveLeft = false;
    private bool moveRight = false;
    [SerializeField]
    private GameObject playerModel;

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
            rotatePlayer(rotationSpeed);
            rotationDirectionLeft = true;
        }
        else if (kb.dKey.isPressed || moveRight)
        {
            translation = speed;
            rotatePlayer(-rotationSpeed);
            rotationDirectionLeft = false;

        }        
        else if(playerModel.transform.rotation.eulerAngles.x > 10  ||
            (playerModel.transform.rotation.eulerAngles.x < 350 && playerModel.transform.rotation.eulerAngles.x > 10) ||
            playerModel.transform.rotation.eulerAngles.y > 260)
        {
            float rotationSpeedLocal = rotationDirectionLeft ? -rotationSpeed: rotationSpeed;            
            playerModel.transform.RotateAround(new Vector3(0, 0, 1), rotationSpeedLocal * Time.deltaTime);
        }
        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(translation, 0, 0);
    }

    private void rotatePlayer(float rotationSpeed)
    {
        

        if (playerModel.transform.rotation.eulerAngles.x >= 320 
            || playerModel.transform.rotation.eulerAngles.x <= 45)
        {
            playerModel.transform.RotateAround(new Vector3(0, 0, 1), rotationSpeed * Time.deltaTime);
           // playerModel.transform.Rotate(new Vector3(rotationSpeed * Time.deltaTime, 0, 0));
        }
        else if ((rotationSpeed > 0 && !rotationDirectionLeft)
           || (rotationSpeed < 0 && rotationDirectionLeft))
        {
            rotationSpeed *= 1.5f;
            playerModel.transform.RotateAround(new Vector3(0, 0, 1), rotationSpeed * Time.deltaTime);
        }
    }

    public void setMoveLeft(bool moveLeft)
    {
        this.moveLeft = moveLeft;
    }

    public void setMoveRight(bool moveRight)
    {
        this.moveRight = moveRight;
    }

}
