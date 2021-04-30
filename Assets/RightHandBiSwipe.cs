using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class RightHandBiSwipe : MonoBehaviour
{
    public Text debug;
    public HandTracker handtracker;
    public OVRHand rightHand;
    public List<GameObject> availableScopes = new List<GameObject>();
    public GameObject currentScope;
    public GameObject currentSelection;

    private int movingDirection;
    // 0-up, 1-left, 2-down, 3-right
    private int movingSpeed;
    // 0-stopped, 1
    private float horizontalDisplacement;
    private float verticalDisplacement;
    private int framePass;
    private AudioSource audioSource;


    private void Start()
    {
        currentScope = availableScopes[0];
        currentSelection = getCentralButton();
        movingDirection = 0;
        movingSpeed = 0;
        audioSource = GetComponent<AudioSource>();
    }

    private bool getCurrentScope()
    {
        foreach(GameObject scope in availableScopes)
        {
            if(scope.activeInHierarchy)
            {
                if(currentScope == scope)
                {
                    return true;
                }
                else
                {
                    currentScope = scope;
                    return false;
                }
            }
        }
        return false;
    }

    private int getVerticalCentralButtonIndex()
    {
        int horizontalY = (int)currentScope.transform.localPosition.y;
        //debug.text = horizontalY.ToString();
        if ((int)horizontalY == -726) return 12;
        if ((int)horizontalY == -451) return 17;
        if ((int)horizontalY == -175) return 22;
        if ((int)horizontalY == 131) return 27;
        if ((int)horizontalY == 431) return 32;
        if ((int)horizontalY == 719) return 37;
        return 12;
    }

    private int getHorizontalCentralButtonIndex()
    {
        int horizontalX = (int)currentScope.transform.localPosition.x;
        //debug.text = horizontalX.ToString();
        if ((int)horizontalX == -728) return 27;
        if ((int)horizontalX == -473) return 26;
        if ((int)horizontalX == -169) return 25;
        if ((int)horizontalX == 128) return 24;
        if ((int)horizontalX == 431) return 23;
        if ((int)horizontalX == 728) return 22;
        return 22;
    }

    private GameObject getCentralButton()
    {
        int scopeIndex = availableScopes.IndexOf(currentScope);
        if (scopeIndex == 0 || scopeIndex == 2)
        {
            // vertical
            return currentScope.transform.GetChild(getVerticalCentralButtonIndex()).gameObject;
        }
        else
        {
            // horizontal
            return currentScope.transform.GetChild(getHorizontalCentralButtonIndex()).gameObject;
        }
    }

    private void highlightSelection()
    {
        //currentSelection.GetComponent<Button>().Select();
        if (currentSelection.GetComponent<Image>().color == new Color(2.0f, 1.0f, 1.0f, 1.0f))
        {
            currentSelection.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
        currentSelection.GetComponent<Image>().color = (currentSelection.GetComponent<Image>().color + Color.cyan) / 2;
    }

    private void dehighlightSelection()
    {
        currentSelection.GetComponent<Image>().color = currentSelection.GetComponent<Image>().color * 2 - Color.cyan;
    }

    private void getCursorMovement()
    {
        horizontalDisplacement = handtracker.rightHandPosition.x;
        verticalDisplacement = handtracker.rightHandPosition.y;
        if (rightHand.GetFingerPinchStrength(OVRHand.HandFinger.Index) > 0.95 && (Math.Abs(horizontalDisplacement) > 0.05 || Math.Abs(verticalDisplacement) > 0.05) && framePass > 25)
        {
            if (Math.Abs(horizontalDisplacement) > Math.Abs(verticalDisplacement))
            {
                // horizontal move
                if (horizontalDisplacement > 0)
                {
                    // right swipe
                    movingDirection = 3;
                    movingSpeed = 1;
                }
                else
                {
                    // left swipe
                    movingDirection = 1;
                    movingSpeed = 1;
                }
            }
            else
            {
                // vertical move
                if (verticalDisplacement > 0)
                {
                    movingDirection = 0;
                    movingSpeed = 1;
                }
                else
                {
                    // down swipe
                    movingDirection = 2;
                    movingSpeed = 1;
                }
            }
            framePass = 0;
        }
        else
        {
            movingSpeed = 0;
        }
    }

    private void moveCursorLeft()
    {
        int scopeIndex = availableScopes.IndexOf(currentScope);
        int selectionIndex = currentSelection.transform.GetSiblingIndex();
        if (scopeIndex == 0 || scopeIndex == 2)
        {
            // vertical
            if (selectionIndex % 5 != 0)
            {
                //not leftmost
                selectionIndex = selectionIndex - movingSpeed;
                currentSelection = currentScope.transform.GetChild(selectionIndex).gameObject;
            } 
        }
        else
        {
            //horizontal
            if (selectionIndex % 10 != 0)
            {
                int middleIndex = getHorizontalCentralButtonIndex();
                int leftMostCol = (middleIndex - 2) % 10;
                //debug.text = selectionIndex.ToString()+" "+leftMostCol;
                //int tentativeSelection = selectionIndex - movingSpeed;
                if ((selectionIndex - movingSpeed) % 10 < leftMostCol)
                {
                    // if (middleIndex == 22) currentScope.transform.position = new Vector3(728, -12.5f, 0);
                    if (middleIndex == 23) currentScope.transform.localPosition = new Vector3(728, -12.5f, 0);
                    if (middleIndex == 24) currentScope.transform.localPosition = new Vector3(431, -12.5f, 0);
                    if (middleIndex == 25) currentScope.transform.localPosition = new Vector3(128, -12.5f, 0);
                    if (middleIndex == 26) currentScope.transform.localPosition = new Vector3(-169, -12.5f, 0);
                    if (middleIndex == 27) currentScope.transform.localPosition = new Vector3(-473, -12.5f, 0);
                }
                selectionIndex = selectionIndex - movingSpeed;
                currentSelection = currentScope.transform.GetChild(selectionIndex).gameObject;
            }
        }
    }

    private void moveCursorRight()
    {
        int scopeIndex = availableScopes.IndexOf(currentScope);
        int selectionIndex = currentSelection.transform.GetSiblingIndex();
        if (scopeIndex == 0 || scopeIndex == 2)
        {
            // vertical
            if (selectionIndex % 5 != 4)
            {
                //not rightmost
                selectionIndex = selectionIndex + movingSpeed;
                currentSelection = currentScope.transform.GetChild(selectionIndex).gameObject;
            }
        }
        else
        {
            //horizontal
            if (selectionIndex % 10 != 9)
            {
                int middleIndex = getHorizontalCentralButtonIndex();
                int rightMostCol = (middleIndex + 2) % 10;
                //debug.text = selectionIndex.ToString()+" "+rightMostCol;
                if ((selectionIndex + movingSpeed) % 10 > rightMostCol)
                {
                    //currentScope.transform.localPosition = currentScope.transform.localPosition - new Vector3(300, 0, 0);
                    if (middleIndex == 22) currentScope.transform.localPosition = new Vector3(431, -12.5f, 0);
                    if (middleIndex == 23) currentScope.transform.localPosition = new Vector3(128, -12.5f, 0);
                    if (middleIndex == 24) currentScope.transform.localPosition = new Vector3(-169, -12.5f, 0);
                    if (middleIndex == 25) currentScope.transform.localPosition = new Vector3(-473, -12.5f, 0);
                    if (middleIndex == 26) currentScope.transform.localPosition = new Vector3(-728, -12.5f, 0);
                }
                selectionIndex = selectionIndex + movingSpeed;
                currentSelection = currentScope.transform.GetChild(selectionIndex).gameObject;
            }
        }
    }

    private void moveCursorUp()
    {
        int scopeIndex = availableScopes.IndexOf(currentScope);
        int selectionIndex = currentSelection.transform.GetSiblingIndex();
        if (scopeIndex == 0 || scopeIndex == 2)
        {
            //vertical
            if (selectionIndex / 5 != 0)
            {
                int middleIndex = getVerticalCentralButtonIndex();
                int upMostRow = (middleIndex - 12) / 5;
                //debug.text = selectionIndex.ToString()+" "+leftMostCol;
                //int tentativeSelection = selectionIndex - movingSpeed;
                if ((selectionIndex - movingSpeed * 5) / 5 < upMostRow)
                {
                    // if (middleIndex == 22) currentScope.transform.position = new Vector3(728, -12.5f, 0);
                    if (middleIndex == 17) currentScope.transform.localPosition = new Vector3(0, -726, 0);
                    if (middleIndex == 22) currentScope.transform.localPosition = new Vector3(0, -451, 0);
                    if (middleIndex == 27) currentScope.transform.localPosition = new Vector3(0, -175, 0);
                    if (middleIndex == 32) currentScope.transform.localPosition = new Vector3(0, 131, 0);
                    if (middleIndex == 37) currentScope.transform.localPosition = new Vector3(0, 431, 0);
                }
                selectionIndex = selectionIndex - movingSpeed * 5;
                currentSelection = currentScope.transform.GetChild(selectionIndex).gameObject;
            }

           
        }
        else
        {
            // horizontal
            if (selectionIndex / 10 != 0)
            {
                //not leftmost
                selectionIndex = selectionIndex - movingSpeed * 10;
                currentSelection = currentScope.transform.GetChild(selectionIndex).gameObject;
            }
        }
    }

    private void moveCursorDown()
    {
        int scopeIndex = availableScopes.IndexOf(currentScope);
        int selectionIndex = currentSelection.transform.GetSiblingIndex();
        if (scopeIndex == 0 || scopeIndex == 2)
        {
            //vertical
            if (selectionIndex / 5 != 9)
            {
                int middleIndex = getVerticalCentralButtonIndex();
                int downMostRow = (middleIndex + 12) / 5;
                //debug.text = selectionIndex.ToString()+" "+leftMostCol;
                //int tentativeSelection = selectionIndex - movingSpeed;
                if ((selectionIndex + movingSpeed * 5) / 5 > downMostRow)
                {
                    // if (middleIndex == 22) currentScope.transform.position = new Vector3(728, -12.5f, 0);
                    if (middleIndex == 12) currentScope.transform.localPosition = new Vector3(0, -451, 0);
                    if (middleIndex == 17) currentScope.transform.localPosition = new Vector3(0, -175, 0);
                    if (middleIndex == 22) currentScope.transform.localPosition = new Vector3(0, 131, 0);
                    if (middleIndex == 27) currentScope.transform.localPosition = new Vector3(0, 431, 0);
                    if (middleIndex == 32) currentScope.transform.localPosition = new Vector3(0, 719, 0);
                }
                selectionIndex = selectionIndex + movingSpeed * 5;
                currentSelection = currentScope.transform.GetChild(selectionIndex).gameObject;
            }


        }
        else
        {
            // horizontal
            if (selectionIndex / 10 != 4)
            {
                //not leftmost
                selectionIndex = selectionIndex + movingSpeed * 10;
                currentSelection = currentScope.transform.GetChild(selectionIndex).gameObject;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        dehighlightSelection();
        if (!getCurrentScope())
        {
            currentSelection = getCentralButton();
        }
        getCursorMovement();
        //debug.text = movingDirection.ToString() + " " + movingSpeed.ToString();
        if (movingSpeed != 0)
        {
            if (movingDirection == 0)
            {
                moveCursorUp();
            }
            if (movingDirection == 1)
            {
                moveCursorLeft();
            }
            if (movingDirection == 2)
            {
                moveCursorDown();
            }
            else if (movingDirection == 3)
            {
                moveCursorRight();
            }
        }
        else
        {
            if (rightHand.GetFingerIsPinching(OVRHand.HandFinger.Middle) && framePass > 15)
            {
                audioSource.Play();
                currentSelection.GetComponent<SmallButtonBehavior>().OnHandClick();
                framePass = 0;
            }
        }
        highlightSelection();
        framePass++;
    }
}
