using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnButtonLeft : MonoBehaviour
{  
    public GameObject player;

    public void onPointerDownRaceButton()
    {
        player.GetComponent<PlayerMovement>().setMoveLeft(true);
    }

    public void onPointerUpRaceButton()
    {
        player.GetComponent<PlayerMovement>().setMoveLeft(false) ;
    }
}
