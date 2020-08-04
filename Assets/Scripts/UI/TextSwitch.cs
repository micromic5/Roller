using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSwitch : MonoBehaviour
{
    [SerializeField]
    string[] textSwitchArray;

    void Start()
    {
        GetComponent<Text>().text = textSwitchArray[Random.Range(0 , textSwitchArray.Length-1)];
    }
}
