using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class TabButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private int tabIndex;
    private Image image;
    public TabController tabController;
    private bool isActive = false;
    private Color activeColor;
    private Color focusColor;
    private Color inactiveColor;

    public void OnPointerClick(PointerEventData eventData)
    {
        tabController.ButtonMouseClick(tabIndex);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isActive)
        {
            image.color = focusColor;
        }
        tabController.ButtonMouseEnter(tabIndex);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isActive)
        {
            image.color = inactiveColor;
        }
        tabController.ButtonMouseExit(tabIndex);
    }

    // Start is called before the first frame update
    private void Awake()
    {
        image = GetComponent<Image>();
        activeColor = Color.blue;
        inactiveColor = Color.white;
        focusColor = Color.cyan;
    }

    public void SetIndex(int index)
    {
        tabIndex = index;
    }

    public void ToggleActive()
    {
        isActive = !isActive;
        if (isActive)
        {
            image.color = activeColor;
        }
        else
        {
            image.color = inactiveColor;
        }
    }
}
