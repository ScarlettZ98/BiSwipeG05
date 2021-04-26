using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class ScreenControl : MonoBehaviour
{
    public Transform screenPanel;
    public int activeIndex;
    public UnityEvent screenChangeEvent;
    private List<Transform> screens = new List<Transform>();

    public void Awake()
    {
        foreach (Transform panel in screenPanel)
        {
            screens.Add(panel);
        }
        activeIndex = screens.Count - 1;
        HideAllScreens(activeIndex);
    }

    public void switchPrev()
    {
        if (activeIndex == 0)
        {
            activeIndex = screens.Count - 1;
        }
        else
        {
            activeIndex--;
        }
        HideAllScreens(activeIndex);
    }

    public void switchNext()
    {
        if (activeIndex == screens.Count - 1)
        {
            activeIndex = 0;
        }
        else
        {
            activeIndex++;
        }
        HideAllScreens(activeIndex);
    }

    private void HideAllScreens(int index)
    {
        for (int i = 0; i < screens.Count; i++)
        {
            if (i == index)
            {
                screens[index].gameObject.SetActive(true);
            }
            else
            {
                screens[index].gameObject.SetActive(false);
            }
        }
        if (screenChangeEvent != null)
        {
            screenChangeEvent.Invoke();
        }
    }
}
