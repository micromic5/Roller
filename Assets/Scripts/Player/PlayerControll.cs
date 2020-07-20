using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerControll : MonoBehaviour
{
    private Vector3 position;
    [SerializeField]
    private float speed = 5f;
    private static readonly float width = 4f;
    [SerializeField]
    private Transform playerModel;
    private Camera camera;
    private Vector2 pos;
    private PlayerShit playerShitScript;
    private float MinPosYToShit = 0.15f;

    private void Start()
    {
        camera = Camera.main;
        playerShitScript = GetComponent<PlayerShit>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            foreach(Touch touch in Input.touches)
            {
                pos = camera.ScreenToViewportPoint(touch.position);
                if (pos.y > MinPosYToShit)
                {
                    transform.position = Vector3.MoveTowards(transform.position, new Vector3(pos.x * width * 2 - width, transform.position.y, transform.position.z), speed * Time.deltaTime);
                }
                else
                {
                    playerShitScript.shit();
                }
            }            
        }
    }
}
