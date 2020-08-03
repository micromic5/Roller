using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChangeTrigger : MonoBehaviour
{
    [SerializeField]
    AudioClip audioClip;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("Leve2").GetComponent<LevelChangeMove>().moveLevel();
            AudioSource audio = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
            if (audioClip != audio.clip)
            {
                audio.clip = audioClip;
                audio.Play();
            }
        }        
    }
}
