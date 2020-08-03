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
    private static Score score;
    [SerializeField]
    private GameObject[] objectsToDisable;

    void Start()
    {
        stomach = playerData.getStomach();
        stomach.registerSubscriber(this);
        if (score == null)
        {
            score = GameObject.FindObjectOfType<Score>();
        }
    }

    public void reciveEvent(int stomachValue)
    {
        if(stomachValue <= 0)
        {
            stomach.removeSubscripter(this);
            SaveData saveData = SaveSystem.loadData();
            int currentScore = score.getScore();
            if(currentScore > saveData.getScore())
            {
                saveData = new SaveData(currentScore);
                SaveSystem.saveData(saveData);

            }
            foreach (GameObject disable in objectsToDisable)
            {
                Destroy(disable);
            }
            gameUI.SetActive(false);
            GameObject.Find("BackgroundMusic").SetActive(false);
            foreach (Transform transform in GetComponentsInChildren<Transform>(true))
            {
                GameObject child = transform.gameObject;
                child.SetActive(true);
                if(child.name == "HighScorePoints")
                {
                    child.GetComponent<UnityEngine.UI.Text>().text = ": " + saveData.getScore();
                }else if(child.name == "CurrentScorePoints")
                {
                    child.GetComponent<UnityEngine.UI.Text>().text = ": " + currentScore;
                }
            }
        }        
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
