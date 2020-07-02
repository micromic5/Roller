using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour, StomachSubscriber
{
    private Stomach stomach;
    [SerializeField]
    private Slider stomachSlider;
    [SerializeField]
    private int startStomachValue;

    private void Awake()
    {
        stomach = new Stomach(startStomachValue);
    }

    void Start()
    {        
        stomach.registerSubscriber(this);
        InvokeRepeating("decreaseStomach", 4.0f, 4.0f);
    }

    void decreaseStomach()
    {
        stomach.decreaseStomachValue(5);
    }

    public void reciveEvent(int stomachValue)
    {
        stomachSlider.value = stomach.getStomachValue();
    }

    public Stomach getStomach()
    {
        return stomach;
    }
}
