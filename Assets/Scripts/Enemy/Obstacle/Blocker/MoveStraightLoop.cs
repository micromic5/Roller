using UnityEngine;
using static Direction;
public class MoveStraightLoop : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private Direction direction = Direction.FRONT;
    [SerializeField]
    private bool isRandom = false;
    [SerializeField]
    private float maxPosition;
    [SerializeField]
    private float minPosition;
    private bool directionHasChanged = false;
    private float timeBetweenDirectionChanges = 0;
    private float speedBoost = 1;
    private float timeBetweenRandomJumps = 2;
    
    void Update()
    {
        timeBetweenDirectionChanges -= Time.deltaTime;
        timeBetweenRandomJumps -= Time.deltaTime;
        if (timeBetweenDirectionChanges > 0)
        {
            speedBoost = 2;
        }
        else
        {
            speedBoost = 1;
        }
        float translation = Time.deltaTime * (speedBoost * ((directionHasChanged)
            ? speed * -1
            : speed));

        switch (direction)
        {
            case LEFT:
                transform.Translate(-translation, 0, 0);                
                directionHasChanged = isPositionOverLimiter(transform.localPosition.x, maxPosition, minPosition);
                break;
            case RIGHT:
                transform.Translate(translation, 0, 0);
                directionHasChanged = isPositionOverLimiter(transform.localPosition.x, maxPosition, minPosition);
                break;
            case FRONT:
                transform.Translate(0, 0, translation);
                directionHasChanged = isPositionOverLimiter(transform.localPosition.z, maxPosition, minPosition);
                break;
            case BACK:
                transform.Translate(0, 0, -translation);
                directionHasChanged = isPositionOverLimiter(transform.localPosition.z, maxPosition, minPosition);
                break;
            case UP:
                transform.Translate(0, translation, 0);
                directionHasChanged = isPositionOverLimiter(transform.localPosition.y, maxPosition, minPosition);
                break;
            case DOWN:
                transform.Translate(0, -translation, 0);
                directionHasChanged = isPositionOverLimiter(transform.localPosition.y, maxPosition, minPosition);
                break;
        }
        if (isRandom && timeBetweenRandomJumps <= 0)
        {
            switch (direction)
            {
                case LEFT:
                case RIGHT:
                    transform.position = new Vector3(Random.Range(minPosition,maxPosition),transform.position.y,transform.position.z);
                    break;
                case FRONT:
                case BACK:
                    transform.position = new Vector3(transform.position.x, transform.position.y, Random.Range(minPosition, maxPosition));
                    break;
                case UP:
                case DOWN:
                    transform.position = new Vector3(transform.position.x, Random.Range(minPosition, maxPosition), transform.position.z);
                    break;
            }
            timeBetweenRandomJumps = 2f;
        }
    }

    private bool isPositionOverLimiter(float position, float limiter1, float limiter2)
    {
        if(timeBetweenDirectionChanges > 0)
        {            
            return directionHasChanged;
        }        
        
        bool shouldChange =  position > limiter1 || position < limiter2
                    ? !directionHasChanged 
                    : directionHasChanged;

        if (shouldChange != directionHasChanged)
        {
            timeBetweenDirectionChanges = .2f;
        }
        return shouldChange;
    }
}