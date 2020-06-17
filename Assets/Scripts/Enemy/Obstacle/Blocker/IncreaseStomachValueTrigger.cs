using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IncreaseStomachValueTrigger : MonoBehaviour
{

    private int increaseValueAmount = 5;
    //When the Primitive exits the collision, it will change Color
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerData>().getStomach().increaseStomachValue(increaseValueAmount);
            Destroy(gameObject);
            /*Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);*/
        }
    }
}
