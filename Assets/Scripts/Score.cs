using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour, EventHolder
{
    private int score = 580;
    private Text scoreTextField;
    private List<EventSubscriber> subcriberLitst = new List<EventSubscriber>();
    private int level;

    private void Start()
    {
        level = Level.getLevel() <= 1 ? 1 : Level.getLevel();
        scoreTextField = GetComponent<Text>();
    }
    public void increaseScore(int amount)
    {
        score += amount * level;
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
