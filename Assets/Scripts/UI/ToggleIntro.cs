using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleIntro : MonoBehaviour
{
    [SerializeField]
    private Sprite spriteOn;

    [SerializeField]
    private Sprite spriteOff;

    public void toggleIntro()
    {
        if (SaveSystem.loadData().getIsIntroOn() == IntroToggle.OFF)
        {
            SaveSystem.saveData(new SaveData(IntroToggle.ON));
            GetComponent<Image>().sprite = spriteOn;
            transform.Find("On").GetComponent<Image>().enabled = true;
            transform.Find("Off").GetComponent<Image>().enabled = false;
        }
        else
        {
            SaveSystem.saveData(new SaveData(IntroToggle.OFF));
            GetComponent<Image>().sprite = spriteOff;
            transform.Find("On").GetComponent<Image>().enabled = false;
            transform.Find("Off").GetComponent<Image>().enabled = true;
        }

    }
}
