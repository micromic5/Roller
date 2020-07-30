using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitByShitHandler : MonoBehaviour
{
    [SerializeField]
    private int pointsWorth = 5;
    [SerializeField]
    private bool triggerDeathAnimation = true;
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
        GetComponent<CapsuleCollider>().enabled = false;
        if (triggerDeathAnimation)
        {
            GetComponent<MoveStraight>().setSpeed(ENVIRONMENT_SPEED);
            GetComponentInChildren<Animator>().SetBool("HitByShit", true);
        }
    }

    public bool getTriggerDeathAnimation()
    {
        return triggerDeathAnimation;
    }
}
