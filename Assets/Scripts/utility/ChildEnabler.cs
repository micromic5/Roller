using UnityEngine;

public class ChildEnabler : MonoBehaviour
{
    public void enableChilds(bool isEnable)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(isEnable);
        }
    }
}
