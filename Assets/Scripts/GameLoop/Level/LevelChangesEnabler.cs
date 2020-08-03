using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChangesEnabler : MonoBehaviour
{
    private float skippedTime = 180f;
    private int level;
    [SerializeField]
    List<int> levelsThatActivateScript;

    void Start()
    {
        level = Level.getLevel();
        if (level >= 2)
        {
            StartCoroutine(makeChanges());
        }
    }

    private IEnumerator makeChanges()
    {
        if (level == 2 && levelsThatActivateScript.Contains(2))
        {
            ScoreChangeChildEnabler scoreChangeChildEnablerScript = GetComponent<ScoreChangeChildEnabler>();
            if (scoreChangeChildEnablerScript != null)
            {
                scoreChangeChildEnablerScript.enabled = false;
                GetComponent<ChildEnabler>().enableChilds(true);
            }
        }
        else if (level == 3 && levelsThatActivateScript.Contains(3))
        {
            GetComponent<ChildEnabler>().enableChilds(true); // enables also child that are probably allready enabled of level 1 and 2, should be no problem
            if(name == "Level1")
            {
                GameObject.Find("LevelChange").SetActive(false);
                gameObject.SetActive(false);                
            }
            foreach (SpawnObject spawnObjectScript in GetComponentsInChildren<SpawnObject>())
            {
                spawnObjectScript.setSpawnTimer(Random.Range(0, 5));
            }
            yield return new WaitForSeconds(10);
            enabled = false;
        }
    }
}
