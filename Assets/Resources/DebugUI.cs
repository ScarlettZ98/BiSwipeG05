using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugUI : MonoBehaviour
{
    public Text text;
    public GameObject screenControl;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "hello";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = screenControl.GetComponent<ScreenControl>().activeIndex.ToString();
    }
}
