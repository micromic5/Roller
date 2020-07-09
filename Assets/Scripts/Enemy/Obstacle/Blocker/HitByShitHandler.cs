using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitByShitHandler : MonoBehaviour
{
    [SerializeField]
    private int pointsWorth = 5;
    private static Score score;
    private static float ENVIRONMENT_SPEED = 3f;
    private void Start()
    {
        if(score == null)
        {
            score = GameObject.FindObjectOfType<Score>();
        }
    }
    public void fire()
    {
        score.increaseScore(pointsWorth);
        GetComponent<MoveStraight>().setSpeed(ENVIRONMENT_SPEED);
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponentInChildren<Animator>().SetBool("HitByShit" , true);
    }
}
