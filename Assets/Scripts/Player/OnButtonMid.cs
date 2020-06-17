using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnButtonMid : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    public void onClick()
    {
        player.GetComponent<PlayerShit>().setShitButtonClickeTrue();
    }
}
