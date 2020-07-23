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
            GameObject decale;
            if (other.tag != "Blocker" && other.tag != "Player" && other.tag != "People" && other.tag != "Shit")
            {
                decale = instantiateDecale(transform.position);
                decale.transform.Find("Plane").Rotate(0, Random.Range(0, 360), 0);
                instantiateDecale(calculateVectorWithRandomOffset(transform.position, .5f)).transform.Find("Plane").Rotate(0, Random.Range(0, 360), 0);
                instantiateDecale(calculateVectorWithRandomOffset(transform.position, .5f)).transform.Find("Plane").Rotate(0, Random.Range(0, 360), 0);
                shouldDestroy = true;
            }
            else if (other.tag == "People")
            {
                other.GetComponent<HitByShitHandler>().fire();
                decale = instantiateDecale(calculateVectorWithRandomOffset(other.transform.position, 0.5f));
                GameObject decale2 = instantiateDecale(calculateVectorWithRandomOffset(other.transform.position, 0.5f));
                GameObject decale3 = instantiateDecale(calculateVectorWithRandomOffset(other.transform.position, 0.5f));
                prepareDecaleOnPeople(decale);
                prepareDecaleOnPeople(decale2);
                prepareDecaleOnPeople(decale3);
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

    private GameObject instantiateDecale(Vector3 position)
    {
        GameObject decale = Instantiate(shitDecale);
        decale.transform.position = position;
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
