using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    private int score;
    private AudioToggle isSoundOn = AudioToggle.UNKNOWN;
    private IntroToggle isIntroOn = IntroToggle.UNKNOWN;

    public SaveData(int score, AudioToggle isSoundOn, IntroToggle isIntroOn)
    {
        this.score = score;
        this.isSoundOn = isSoundOn;
        this.isIntroOn = isIntroOn;
    }

    public SaveData(int score)
    {
        this.score = score;
        Initialize();
    }
    public SaveData(AudioToggle isSoundOn)
    {
        this.isSoundOn = isSoundOn;
        Initialize();
    }
    public SaveData(IntroToggle isIntroOn)
    {
        this.isIntroOn = isIntroOn;
        Initialize();
    }
    private void Initialize()
    {
        SaveData oldData = SaveSystem.loadData();
        score = score == 0
            ? oldData.score
            : score;

        isSoundOn = isSoundOn == AudioToggle.UNKNOWN
            ? oldData.getIsSoundOn()
            : isSoundOn;
        isIntroOn = isIntroOn == IntroToggle.UNKNOWN
            ? oldData.getIsIntroOn()
            : isIntroOn;
    }
   

    public int getScore()
    {
        return score;
    }

    public AudioToggle getIsSoundOn()
    {
        return isSoundOn;
    }

    public IntroToggle getIsIntroOn()
    {
        return isIntroOn;
    }
}
