using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ShitTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject shitDecale;
    private bool shouldDestroy = false;
    private readonly static float halfPersonHeight = 1.2f;
    private void OnTriggerEnter(Collider other)
    {
        GameObject decale;
        if (other.tag != "Blocker" && other.tag != "Player" && other.tag != "People")
        {
            decale = instantiateDecale(transform.position);         
            shouldDestroy = true;
        }
        else if (other.tag == "People")
        {
            other.GetComponent<HitByShitHandler>().fire();
            decale = instantiateDecale(other.transform.position);
            Vector3 decalePosition = decale.transform.position;
            decale.transform.position = new Vector3(decalePosition.x, decalePosition.y + halfPersonHeight, decalePosition.z);
            foreach (MoveStraight moveStraight in decale.GetComponents<MoveStraight>().Where(moveStraight => moveStraight.getSpeed() == 0))
            {
                moveStraight.setSpeed(1);
            }
            shouldDestroy = true;
        }
        if (shouldDestroy)
        {
            GameObject.Destroy(gameObject);
        }       
    }

    private GameObject instantiateDecale(Vector3 position)
    {
        GameObject decale = Instantiate(shitDecale);
        decale.transform.position = position;
        return decale;
    }
}
