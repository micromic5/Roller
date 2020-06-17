using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    private float timeFromStart = 0f;
    private Text guiText;

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
        guiText.text = timeFromStart.ToString();
    }
}
