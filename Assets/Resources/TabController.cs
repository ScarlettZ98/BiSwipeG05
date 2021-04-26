using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TabController : MonoBehaviour
{
    public Transform buttonPanel;
    public Transform tabPanel;
    public UnityEvent tabChangeEvent;

    private int selectedIndex;
    private TabButton selectedButton;
    private List<TabButton> buttons = new List<TabButton>();
    private List<Transform> panels = new List<Transform>();



    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < buttonPanel.transform.childCount; i++)
        {
            TabButton button = buttonPanel.transform.GetChild(i).gameObject.GetComponent<TabButton>();
            button.SetIndex(i);
            buttons.Add(button);
        }
        foreach (Transform panel in tabPanel)
        {
            panels.Add(panel);
        }
        ButtonMouseClick(0);
    }

    public void ButtonMouseClick(int id)
    {
        if (selectedButton != null)
        {
            selectedButton.ToggleActive();
        }
        selectedIndex = id;
        selectedButton = buttons[selectedIndex];
        selectedButton.ToggleActive();
        HideAllPanels();

    }

    public void ButtonMouseEnter(int _id)
    {
        Debug.Log("Entered");
    }

    public void ButtonMouseExit(int _id)
    {
        Debug.Log("Exited");
    }

    private void HideAllPanels()
    {
        for (int i = 0; i < panels.Count; i++)
        {
            if (i == selectedIndex)
            {
                panels[i].gameObject.SetActive(true);
            }
            else
            {
                panels[i].gameObject.SetActive(false);
            }
        }

        if (tabChangeEvent != null)
        {
            tabChangeEvent.Invoke();
        }
    }
}
