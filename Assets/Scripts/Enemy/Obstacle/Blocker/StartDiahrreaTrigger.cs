using UnityEngine;

public class StartDiahrreaTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {            
            Transform diarrheaContainer = other.transform.Find("diarrhea");
            foreach (Transform child in diarrheaContainer)
            {
                child.gameObject.SetActive(false);
                child.gameObject.SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}
