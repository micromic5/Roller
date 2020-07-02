using System.Collections.Generic;

public class Stomach : StomachEventHolder
{
    private int stomachValue;
    private List<StomachSubscriber> stomachSubcriberLitst = new List<StomachSubscriber>();

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

    public new void registerSubscriber(StomachSubscriber subscriber)
    {
        stomachSubcriberLitst.Add(subscriber);
    }

    public new void removeSubscripter(StomachSubscriber subscriber)
    {
        stomachSubcriberLitst.Remove(subscriber); 
    }

    public new void notifySubscribers()
    {
        foreach (StomachSubscriber subscriber in stomachSubcriberLitst){
            subscriber.reciveEvent(stomachValue);
        }
    }
}
