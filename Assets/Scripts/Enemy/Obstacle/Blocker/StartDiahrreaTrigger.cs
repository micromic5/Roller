using UnityEngine;

public class StartDiahrreaTrigger : MonoBehaviour
{
    private Transform diarrheaContainer = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {            
            diarrheaContainer = diarrheaContainer!=null?diarrheaContainer:other.transform.Find("diarrhea");
            foreach (Transform child in diarrheaContainer)
            {
                child.gameObject.SetActive(false);
                child.gameObject.SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}
