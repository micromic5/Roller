using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreChangeChildEnabler : MonoBehaviour, EventSubscriber
{
    private static Score score;
    [SerializeField]
    private bool enableObject;
    [SerializeField]
    private int scoreThatTriggersAction;

    private void Start()
    {
        if (score == null)
        {
            score = GameObject.FindObjectOfType<Score>();
        }
        score.registerSubscriber(this);
    }

    public void reciveEvent()
    {
        if (score.getScore() >= scoreThatTriggersAction)
        {   
            foreach(Transform child in transform)
            {
                child.gameObject.SetActive(enableObject);
            }            
        }
    }

    private void OnDestroy()
    {
        score.removeSubscripter(this);
    }
}
