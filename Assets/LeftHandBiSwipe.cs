using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LeftHandBiSwipe : MonoBehaviour
{
    public HandTracker handtracker;
    public OVRHand leftHand;
    public Transform leftAnchor;
    public Transform rightAnchor;
    public GameObject Screen0;
    public GameObject Screen1;
    //private Vector3 lastPostion;
    //private Vector3 currentPosition;
    private float horizontalDisplacement;
    private float verticalDisplacement;
    private int framePass;
    private float handDistance;
    private float threshold;
   


    // Start is called before the first frame update
    void Start()
    {
        //lastPostion = handtracker.leftHandPostion;
        //currentPosition = lastPostion;
        handDistance = Math.Abs(leftAnchor.position.x - rightAnchor.position.x);
        threshold = handDistance / 2 * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        framePass++;
        //currentPosition = handtracker.leftHandPostion;
        //displacement = currentPosition - lastPostion;
        //horizontalDisplacement = displacement.x;
        //verticalDisplacement = displacement.y;
        //lastPostion = currentPosition;
        horizontalDisplacement = handtracker.leftHandPostion.x;
        verticalDisplacement = handtracker.leftHandPostion.y;
        //if (leftHand.GetFingerPinchStrength(OVRHand.HandFinger.Index) > 0.99 && (Math.Abs(horizontalDisplacement) > 0.05 || Math.Abs(verticalDisplacement) > 0.05) && framePass > 50)
        if (leftHand.GetFingerPinchStrength(OVRHand.HandFinger.Index) > 0.99 && (Math.Abs(horizontalDisplacement) > threshold || Math.Abs(verticalDisplacement) > threshold) && framePass > 50)

        {
            //debug.text = horizontalDisplacement.ToString("F3") + " " + verticalDisplacement.ToString("F3");
            if (Math.Abs(horizontalDisplacement) > Math.Abs(verticalDisplacement))
            {
                // horizontal move
                if (horizontalDisplacement > 0)
                {
                    // right swipe
                    //debug.text = "right";
                    Screen0.SetActive(false);
                    Screen1.SetActive(true);
                }
                else
                {
                    // left swipe
                    //debug.text = "left";
                    Screen1.SetActive(false);
                    Screen0.SetActive(true);
                }
            }
            else
            {
                // vertical move
                if (verticalDisplacement > 0)
                {
                    // up swipe
                    // debug.text = "up";
                    if (Screen0.activeInHierarchy)
                    {
                        Screen0.GetComponent<TabController>().ButtonMouseClick(0);
                    }
                    else
                    {
                        Screen1.GetComponent<TabController>().ButtonMouseClick(0);
                    }
                }
                else
                {
                    // down swipe
                    // debug.text = "down";
                    if (Screen0.activeInHierarchy)
                    {
                        Screen0.GetComponent<TabController>().ButtonMouseClick(1);
                    }
                    else
                    {
                        Screen1.GetComponent<TabController>().ButtonMouseClick(1);
                    }
                }
            }
        }
        
    }
}
