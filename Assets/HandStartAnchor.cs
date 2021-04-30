using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandStartAnchor : MonoBehaviour
{
    public GameObject handtracker;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter");
        handtracker.SetActive(true);
        gameObject.SetActive(false);
    }

}
