using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{ 
    public void startGame(int level)
    {
        Level.setLevel(level);
        GameObject.Find("Intro").GetComponent<ChildEnabler>().enableChilds(true);
        StartCoroutine(changeScene());
    }

    IEnumerator changeScene()
    {
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("Game");
    }
}
