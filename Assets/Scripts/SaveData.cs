using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    private int score = 0;

    public SaveData(int score)
    {
        this.score = score;
    }

    public int getScore()
    {
        return score;
    }
}
