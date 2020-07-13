using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnButtonRight : MonoBehaviour
{
    public GameObject player;

    public void onPointerDownRaceButton()
    {
        player.GetComponent<PlayerMovement>().setMoveRight(true);
    }

    public void onPointerUpRaceButton()
    {
        player.GetComponent<PlayerMovement>().setMoveRight(false);
    }
}
