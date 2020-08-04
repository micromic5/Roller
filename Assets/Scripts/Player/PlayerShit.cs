using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShit : MonoBehaviour
{
    [SerializeField]
    private GameObject shitGameObject;
    [SerializeField]
    private Transform spawnPosition;
    [SerializeField]
    private ParticleSystem shitParticles;
    private float shitterCooldown = .7f;
    private float shitterCooldownCountDown = 0f;
    private int decreaseAmount = 10;
    private Keyboard kb;
    private bool shitButtonClicked = false;
    private AudioSource audioSource;
    [SerializeField]
    AudioClip[] poopSounds;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        kb = InputSystem.GetDevice<Keyboard>();
    }

    void Update()
    {          
        shitterCooldownCountDown += Time.deltaTime;
    if (kb.spaceKey.isPressed)
    {
        shit();
    }
    }

    public void shit()
    {
        if (shitterCooldownCountDown >= shitterCooldown)
        {
            GetComponent<PlayerData>().getStomach().decreaseStomachValue(decreaseAmount);
            GameObject spawnedObject = Instantiate(shitGameObject, spawnPosition);
            shitterCooldownCountDown = 0;
            shitButtonClicked = false;
            shitParticles.Play();
            spawnedObject.transform.parent = null;
            playRandomShitSound();
        }
    }

    private void playRandomShitSound()
    {
        audioSource.clip = poopSounds[Random.Range(0, poopSounds.Length - 1)];
        audioSource.Play();
    }
}
