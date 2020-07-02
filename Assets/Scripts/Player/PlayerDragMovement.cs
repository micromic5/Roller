using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDragMovement : MonoBehaviour
{
    private Vector3 position;
    private float width;
    private float height;
    [SerializeField]
    private float speed = 10f;
    private float maxLeft = -5.2f;
    private float maxRight = 5.2f;

    void Awake()
    {
        width = (float)Screen.width / 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Move the cube if the screen has the finger moving.
           /* if (touch.phase == TouchPhase.Moved)
            {*/
                Vector2 pos = touch.position;
                pos.x = ((pos.x - width) / width) * Time.deltaTime * speed;
                pos.x = (pos.x < maxLeft) ? maxLeft : (pos.x > maxRight) ? maxRight : pos.x;
                // Position the cube.
                transform.Translate(pos.x, 0, 0);
           // }
        }
    }
}
