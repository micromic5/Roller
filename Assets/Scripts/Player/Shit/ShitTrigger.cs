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
        if (shouldCollide(other.tag))
        {
            MoveStraight moveStraight = other.GetComponent<MoveStraight>();
            GameObject decale = null;
            GameObject decale2 = null;
            GameObject decale3 = null;
            if (other.tag != "Blocker" && other.tag != "Player" && other.tag != "People" && other.tag != "Shit")
            {
                decale = instantiateDecale(transform.position, other);                
                decale2 = instantiateDecale(calculateVectorWithRandomOffset(transform.position, .5f), other);
                decale3 = instantiateDecale(calculateVectorWithRandomOffset(transform.position, .5f), other);
                decale.transform.Find("Plane").Rotate(0, Random.Range(0, 360), 0);
                decale2.transform.Find("Plane").Rotate(0, Random.Range(0, 360), 0);
                decale3.transform.Find("Plane").Rotate(0, Random.Range(0, 360), 0);
                shouldDestroy = true;
            }
            else if (other.tag == "People")
            {
                other.GetComponent<HitByShitHandler>().fire();
                decale = instantiateDecale(calculateVectorWithRandomOffset(other.transform.position, 0.5f), other);
                decale2 = instantiateDecale(calculateVectorWithRandomOffset(other.transform.position, 0.5f), other);
                decale3 = instantiateDecale(calculateVectorWithRandomOffset(other.transform.position, 0.5f), other);
                if (other.GetComponent<HitByShitHandler>().getTriggerDeathAnimation())
                {
                    prepareDecaleOnPeople(decale);
                    prepareDecaleOnPeople(decale2);
                    prepareDecaleOnPeople(decale3);
                }
                
                shouldDestroy = true;
            }
            if (shouldDestroy)
            {
                GameObject.Destroy(gameObject);
            }
        }
    }

    private bool shouldCollide(string tag)
    {
        return !(tag == "Food" || tag == "Virus");
    }

    private GameObject instantiateDecale(Vector3 position, Collider other)
    {
        GameObject decale = Instantiate(shitDecale);
        decale.transform.position = position;
        if (other.tag == "CarParts")
        {
            MoveStraight moveStraight = other.GetComponentInParent<MoveStraight>();
            float speed = moveStraight.getSpeed();
            foreach (MoveStraight moveStraightScript in decale.GetComponents<MoveStraight>())
            {
                if (moveStraightScript.getDirection() == Direction.BACK)
                    moveStraightScript.setSpeed(speed);
            }
        }
        return decale;
    }

    private Vector3 calculateVectorWithRandomOffset(Vector3 originVector, float offset)
    {
        return new Vector3(
            Random.Range(originVector.x - .5f, originVector.x + .5f),
            originVector.y,
            Random.Range(originVector.z - .5f, originVector.z + .5f));
    }

    private void prepareDecaleOnPeople(GameObject decale)
    {
        decale.transform.Find("Plane").Rotate(0, Random.Range(0, 360), 0);
        Vector3 decalePosition = decale.transform.position;
        decale.transform.position = new Vector3(decalePosition.x, decalePosition.y + halfPersonHeight, decalePosition.z);
        foreach (MoveStraight moveStraight in decale.GetComponents<MoveStraight>().Where(moveStraight => moveStraight.getSpeed() == 0))
        {
            moveStraight.setSpeed(1);
        }
    }
}
