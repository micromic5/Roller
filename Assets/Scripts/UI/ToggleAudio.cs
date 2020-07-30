using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleAudio : MonoBehaviour
{
    [SerializeField]
    private Sprite spriteOn;

    [SerializeField]
    private Sprite spriteOff;

    public void toggleAudio()
    {
        if (SaveSystem.loadData().getIsSoundOn() == AudioToggle.OFF)
        {
            SaveSystem.saveData(new SaveData(AudioToggle.ON));
            AudioListener.pause = false;
            GetComponent<Image>().sprite = spriteOn;
            transform.Find("On").GetComponent<Image>().enabled = true;
            transform.Find("Off").GetComponent<Image>().enabled = false;
        }
        else
        {
            SaveSystem.saveData(new SaveData(AudioToggle.OFF));
            AudioListener.pause = true;
            GetComponent<Image>().sprite = spriteOff;
            transform.Find("On").GetComponent<Image>().enabled = false;
            transform.Find("Off").GetComponent<Image>().enabled = true;
        }
    }
}
