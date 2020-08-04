using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetAudioAndIntro : MonoBehaviour
{
    private SaveData startSaveData;
    [SerializeField]
    private GameObject introToggleUI;
    [SerializeField]
    private GameObject audioToggleUI;
    [SerializeField]
    private Sprite spriteOff;

    private void Start()
    {
        startSaveData = SaveSystem.loadData();
        if (startSaveData.getIsSoundOn() == AudioToggle.OFF)
        {
            audioToggleUI.GetComponent<Image>().sprite = spriteOff;
            AudioListener.pause = true;
        }
        if (startSaveData.getIsIntroOn() == IntroToggle.OFF)
        {
            introToggleUI.GetComponent<Image>().sprite = spriteOff;
        }
    }

    public SaveData getSaveData()
    {
        return startSaveData;
    }
}