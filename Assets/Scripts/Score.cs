using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour, EventHolder
{
    private int score = 0;
    private Text scoreTextField;
    private List<EventSubscriber> subcriberLitst = new List<EventSubscriber>();

    private void Start()
    {
        scoreTextField = GetComponent<Text>();
    }
    public void increaseScore(int amount)
    {
        score += amount;
        scoreTextField.text = score.ToString();
        notifySubscribers();
    }

    public int getScore()
    {
        return score;
    }

    public void registerSubscriber(EventSubscriber subscriber)
    {
        subcriberLitst.Add(subscriber);
    }

    public void removeSubscripter(EventSubscriber subscriber)
    {
        subcriberLitst.Remove(subscriber);
    }

    public void notifySubscribers()
    {
        foreach (EventSubscriber subscriber in subcriberLitst)
        {
            subscriber.reciveEvent();
        }
    }
}
