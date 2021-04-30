using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SmallButtonBehavior : MonoBehaviour, IPointerClickHandler
{
    public bool isTarget;
    public bool isTriggered;
    public FeedbackManager feedbackManager;

    // Start is called before the first frame update
    void Awake()
    {
        isTarget = false;
        //isTriggered = false;
        feedbackManager = FindObjectOfType<FeedbackManager>();
    }

    public void getSelected()
    {
        GetComponent<Image>().color = Color.red;
        isTarget = true;
    }

    public void getDeselected()
    {
        GetComponent<Image>().color = Color.white;
        isTarget = false;
        //isTriggered = false;
    }

    public void OnClick()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isTarget)
        {
            //isTriggered = true;
            feedbackManager.timerRunning = false;
        }
    }

    public void OnHandClick()
    {
        if (isTarget)
        {
            //isTriggered = true;
            feedbackManager.timerRunning = false;
        }
    }
}
