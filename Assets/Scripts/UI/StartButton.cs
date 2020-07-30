using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    private IntroToggle introToggle;
    public void startGame(int level)
    {
        introToggle = SaveSystem.loadData().getIsIntroOn();
        Level.setLevel(level);
        if (introToggle == IntroToggle.ON)
        {
            GameObject.Find("Intro").GetComponent<ChildEnabler>().enableChilds(true);
            GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().volume = 0.1f;
        }        
        StartCoroutine(changeScene());
    }

    IEnumerator changeScene()
    {
        if(introToggle == IntroToggle.OFF)
        {
            yield return new WaitForSeconds(0.2f);
            SceneManager.LoadScene("Game");
        }
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("Game");
    }
}
