using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShit : MonoBehaviour
{
    [SerializeField]
    private GameObject shit;
    [SerializeField]
    private Transform spawnPosition;
    [SerializeField]
    private ParticleSystem shitParticles;
    private float shitterCooldown = 1f;
    private float shitterCooldownCountDown = 0f;
    private int decreaseAmount = 10;
    private Keyboard kb;
    private bool shitButtonClicked = false;
    private void Start()
    {
        kb = InputSystem.GetDevice<Keyboard>();
    }

    // Update is called once per frame
      void Update()
      {
          if(shitterCooldownCountDown >= shitterCooldown)
          {
            if (kb.spaceKey.isPressed || shitButtonClicked)
            {
                GetComponent<PlayerData>().getStomach().decreaseStomachValue(decreaseAmount);
                GameObject spawnedObject = Instantiate(shit);
                spawnedObject.transform.position = spawnPosition.position;
                shitterCooldownCountDown = 0;
                shitButtonClicked = false;
                shitParticles.Play();
            }
          }
          shitterCooldownCountDown += Time.deltaTime;
      }

    public void setShitButtonClickeTrue()
    {
        shitButtonClicked = true;
    }
}
