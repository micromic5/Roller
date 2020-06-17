using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Stomach : EventHolder
{
    private int stomachValue;
    private List<EventSubscriber> stomachSubcriberLitst = new List<EventSubscriber>();

    public Stomach(int startValue)
    {
        stomachValue = startValue;
    }

    public void increaseStomachValue(int value)
    {        
        if (stomachValue + value >= 100)
        {
            stomachValue = 100;
        }
        else
        {
            stomachValue += value;
        }
        notifySubscribers();
    }

    public void decreaseStomachValue(int value)
    {
        if(stomachValue - value <= 0)
        {
            stomachValue = 0;
            endGame();
        }
        else
        {
            stomachValue -= value;            
        }
        notifySubscribers();
    }
    public float getStomachValue()
    {
        return stomachValue/100f;
    }

    public new void registerSubscriber(EventSubscriber subscriber)
    {
        stomachSubcriberLitst.Add(subscriber);
    }

    public new void removeSubscripter(EventSubscriber subscriber)
    {
        stomachSubcriberLitst.Remove(subscriber); 
    }

    public new void notifySubscribers()
    {
        foreach (EventSubscriber subscriber in stomachSubcriberLitst){
            subscriber.reciveEvent();
        }
    }

    private void endGame()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }
}
