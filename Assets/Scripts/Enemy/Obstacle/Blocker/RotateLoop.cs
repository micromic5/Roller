using UnityEngine;

public class RotateLoop : MonoBehaviour
{
    [SerializeField]
    private float speed = 50;
    
    void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
        speed += speed <= 2000? 10* Time.deltaTime: 0;
    }
}
