using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Direction;
public class MoveStraightLoop : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private Direction direction = Direction.FRONT;
    [SerializeField]
    private float timeTillDirectionChange = 1f;
    private bool directionHasChanged = false;
    private float directionChangeTimer;

    private void Start()
    {
        directionChangeTimer = timeTillDirectionChange;
    }
    // Update is called once per frame
    void Update()
    {
        directionChangeTimer -= 1 * Time.deltaTime;
        if (directionChangeTimer <= 0)
        {
            directionHasChanged = !directionHasChanged;
            directionChangeTimer = timeTillDirectionChange;
        }

        float translation = Time.deltaTime * ((directionHasChanged)
            ? speed * -1
            : speed);

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
        }

    }
}
