using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitByShitHandler : MonoBehaviour
{
    [SerializeField]
    private int pointsWorth = 5;
    private static Score score;

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
        GetComponent<MoveStraight>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponentInChildren<Animator>().SetBool("HitByShit" , true);
    }
}
