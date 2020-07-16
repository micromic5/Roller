using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerDragMovement : MonoBehaviour
{
    private Vector3 position;
    [SerializeField]
    private float speed = 5f;
    private static readonly float width = 4f;
    [SerializeField]
    private Transform playerModel;
    private Camera camera;
    private Vector2 pos;

    private void Start()
    {
        camera = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            pos = camera.ScreenToViewportPoint(touch.position);
            transform.position = new Vector3(Mathf.Lerp(transform.position.x, pos.x * width*2 - width, speed * Time.deltaTime), transform.position.y, transform.position.z);//Vector3.Slerp(transform.position, new Vector3(pos.x * 9 - 4.5f, transform.position.y, transform.position.z), speed * Time.deltaTime);
        }
    }
}
