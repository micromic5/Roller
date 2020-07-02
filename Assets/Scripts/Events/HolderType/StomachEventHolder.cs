using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface StomachEventHolder
{
    void registerSubscriber(StomachSubscriber subscriber);
    void removeSubscripter(StomachSubscriber subscriber);
    void notifySubscribers();
}
