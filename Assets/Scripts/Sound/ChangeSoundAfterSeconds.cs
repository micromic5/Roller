using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSoundAfterSeconds : MonoBehaviour
{
    [SerializeField]
    AudioClip audioClip;
    float secondsTillAudiChange = 0f;
    private void Start()
    {
        StartCoroutine(changeAudio());
    }


    private IEnumerator changeAudio()
    {
        yield return new WaitForSeconds(secondsTillAudiChange);        
        AudioSource audio = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
        if (audioClip != audio.clip)
        {
            audio.clip = audioClip;
            audio.Play();
        }            
    }
}
