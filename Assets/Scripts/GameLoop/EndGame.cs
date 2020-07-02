using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour, StomachSubscriber
{ 
    private Stomach stomach;
    [SerializeField]
    private PlayerData playerData;
    [SerializeField]
    private GameObject gameUI;

    void Start()
    {
        stomach = playerData.getStomach();
        stomach.registerSubscriber(this);
    }

    public void reciveEvent(int stomachValue)
    {
        if(stomachValue <= 0)
        {
            stomach.removeSubscripter(this);
            gameUI.SetActive(false);
            foreach (Transform transform in GetComponentsInChildren<Transform>(true))
            {
                transform.gameObject.SetActive(true);
            }
        }        
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
