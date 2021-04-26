using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackManager : MonoBehaviour
{
    public float timeUsed;
    private bool buttonTriggered;

    // Start is called before the first frame update
    void Start()
    {
        timeUsed = 0.0f;
        buttonTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonTriggered)
        {
            timeUsed += Time.deltaTime;
        }
    }

    public void ButtonTriggered()
    {
        timeUsed = 100.0f;
        if (buttonTriggered)
        {
            buttonTriggered = false;
        }
        else
        {
            buttonTriggered = true;
        }
    }
}
