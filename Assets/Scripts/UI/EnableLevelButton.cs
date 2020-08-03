using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnableLevelButton : MonoBehaviour
{
    private int pointsToUnlockLevel2 = 100;
    private int pointsToUnlockLevel3 = 600;
    [SerializeField]
    private bool isLevel2Button = false;

    private void Start()
    {
        if(isLevel2Button && SaveSystem.loadData().getScore() >= pointsToUnlockLevel2)
        {
            GetComponent<Button>().interactable = true;
        }else if (!isLevel2Button && SaveSystem.loadData().getScore() >= pointsToUnlockLevel3)
        {
            GetComponent<Button>().interactable = true;
        }
    }
}
