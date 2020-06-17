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
    // Start is called before the first frame update
    void Start()
    {
        stomach = new Stomach(startStomachValue);
        stomach.registerSubscriber(this);
        InvokeRepeating("decreaseStomach", 4.0f, 4.0f);
    }

    void decreaseStomach()
    {
        stomach.decreaseStomachValue(5);
    }

    public void reciveEvent()
    {
        stomachSlider.value = stomach.getStomachValue();
    }

    public Stomach getStomach()
    {
        return stomach;
    }
}
