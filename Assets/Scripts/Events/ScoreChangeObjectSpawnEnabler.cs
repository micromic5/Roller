using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreChangeObjectSpawnEnabler : MonoBehaviour, EventSubscriber
{
    private static Score score;
    [SerializeField]
    private bool enableSpawn;
    [SerializeField]
    private int scoreThatTriggersAction;

    private void Start()
    {
        if (score == null)
        {
            score = GameObject.FindObjectOfType<Score>();
        }
        score.registerSubscriber(this);
    }

    public void reciveEvent()
    {
        if (score.getScore() >= scoreThatTriggersAction)
        {
            foreach(SpawnObject spawnObjectScript in GetComponentsInChildren<SpawnObject>()){
                spawnObjectScript.enabled = enableSpawn;
            }
            GetComponent<DestroySelf>().enabled = true;
        }
    }

    private void OnDestroy()
    {
        score.removeSubscripter(this);
    }
}
