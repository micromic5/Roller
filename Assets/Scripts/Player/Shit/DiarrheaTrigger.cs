using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DiarrheaTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject shitDecale;
    private readonly static float baseTimeBetweenDiarrheaHits = .05f;
    private float timeBetweenDiarrheaHits = .05f;
    private readonly static float halfPersonHeight = 1.2f;

    void Update()
    {
        timeBetweenDiarrheaHits -= Time.deltaTime;
    }
    
    private void OnTriggerStay(Collider other)
    {
        if(timeBetweenDiarrheaHits <= 0)
        {
            GameObject decale;
            if (other.tag != "Blocker" && other.tag != "Player" && other.tag != "People" && other.tag != "Shit")
            {
                decale = instantiateDecale(transform.position);
                decale.transform.Find("Plane").Rotate(0, Random.Range(0, 360), 0);
            }            
            timeBetweenDiarrheaHits = baseTimeBetweenDiarrheaHits;
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "People")
        {
            GameObject decale;
            other.GetComponent<HitByShitHandler>().fire();
            decale = instantiateDecale(other.transform.position);
            Vector3 decalePosition = decale.transform.position;
            decale.transform.position = new Vector3(decalePosition.x, decalePosition.y + halfPersonHeight, decalePosition.z);
            foreach (MoveStraight moveStraight in decale.GetComponents<MoveStraight>().Where(moveStraight => moveStraight.getSpeed() == 0))
            {
                moveStraight.setSpeed(1);
            }
        }
    }

    private GameObject instantiateDecale(Vector3 position)
    {
        GameObject decale = Instantiate(shitDecale);
        decale.transform.position = position;
        return decale;
    }
}
