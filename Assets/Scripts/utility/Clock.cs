using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    private float timeFromStart = 60*80;
    private Text guiText;
    private int flooredFValue = 0;
    private int secondes;
    private void Start()
    {
        guiText = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        timeFromStart += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        flooredFValue = (int)Mathf.Floor(timeFromStart);
        secondes = flooredFValue % 60;
        guiText.text = flooredFValue/60+":"+ ((secondes < 10)?"0"+ secondes : secondes.ToString());
    }
}
