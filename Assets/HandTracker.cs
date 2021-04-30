using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandTracker : MonoBehaviour
{
    public Text debug;
    public GameObject leftHand;
    public GameObject rightHand;
    private Vector3 leftHandStartPostion;
    private Vector3 rightHandStartPosition;
    public Vector3 leftHandPostion;
    public Vector3 rightHandPosition;
    private bool isCalibratedLeft;
    private bool isCalibratedRight;
    public GameObject leftAnchor;
    public GameObject rightAnchor;
    public GameObject leftHandBiswipe;
    public GameObject rightHandBiswipe;

    // Start is called before the first frame update
    void Start()
    {
        debug.text = "Calibrating...";
        isCalibratedLeft = false;
        isCalibratedRight = false;
        leftHandStartPostion = leftHand.GetComponent<OVRHand>().PointerPose.position;
        rightHandStartPosition = rightHand.GetComponent<OVRHand>().PointerPose.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCalibratedLeft)
        {
            if (leftHand.GetComponent<OVRHand>().GetFingerIsPinching(OVRHand.HandFinger.Index))
            {
                debug.text = "Left calibrated";
                leftHandStartPostion = leftHand.GetComponent<OVRHand>().PointerPose.position;
                isCalibratedLeft = true;
                leftAnchor.transform.position = leftHandStartPostion;
            }
        }
        if (!isCalibratedRight)
        {
            if (rightHand.GetComponent<OVRHand>().GetFingerIsPinching(OVRHand.HandFinger.Index))
            {
                debug.text = "Right calibrated";
                rightHandStartPosition = rightHand.GetComponent<OVRHand>().PointerPose.position;
                isCalibratedRight = true;
                rightAnchor.transform.position = rightHandStartPosition;
            }
        }
        if (isCalibratedLeft && isCalibratedRight)
        {
            leftHandPostion = leftHand.GetComponent<OVRHand>().PointerPose.position - leftHandStartPostion;
            rightHandPosition = rightHand.GetComponent<OVRHand>().PointerPose.position - rightHandStartPosition;
            leftHandBiswipe.SetActive(true);
            rightHandBiswipe.SetActive(true);
        }
           
       
    }
}
