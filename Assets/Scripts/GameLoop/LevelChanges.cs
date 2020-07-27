using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChanges : MonoBehaviour
{
    private float skippedTime = 180f;
    private int level;

    void Start()
    {
        level = Level.getLevel();
        if(level >= 2)
        {
            StartCoroutine(makeChanges());
        }        
    }

    private IEnumerator makeChanges()
    {
        yield return new WaitForSeconds(1);
        if (level == 2)
        {
            ScoreChangeChildEnabler scoreChangeChildEnablerScript = GetComponent<ScoreChangeChildEnabler>();
            if(scoreChangeChildEnablerScript != null)
            {
                scoreChangeChildEnablerScript.enabled = false;
                GetComponent<ChildEnabler>().enableChilds(true);
            }            
            ChangeSpeed changeSpeedScript = GetComponentInChildren<ChangeSpeed>();
            if(changeSpeedScript != null)
            {
                changeSpeedScript.setCurrentSpeed(changeSpeedScript.getAamountOfSpeedChange() * (skippedTime / changeSpeedScript.getBaseTimeBetweenSpeedChanges()));
            }
            SpawnObject spawnObjectScript = GetComponentInChildren<SpawnObject>();
            if (spawnObjectScript != null && spawnObjectScript.getSpawnTimeChanger() != 0)
            {
                Debug.Log(spawnObjectScript.getSpawnTimeChanger() * (skippedTime / spawnObjectScript.getTimeBetweenSpawn()));
                spawnObjectScript.addToTimeBetweenSpawn(spawnObjectScript.getSpawnTimeChanger() * (skippedTime / spawnObjectScript.getTimeBetweenSpawn()));
            }
        }
    }
}
