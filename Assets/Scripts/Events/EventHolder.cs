using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface EventHolder 
{
    void registerSubscriber(EventSubscriber subscriber);
    void removeSubscripter(EventSubscriber subscriber);
    void notifySubscribers();
}
