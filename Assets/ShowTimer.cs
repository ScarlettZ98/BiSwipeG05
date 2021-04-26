using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTimer : MonoBehaviour
{
    [SerializeField]
    public GameObject feedbackManager;
    public Text textBox;
    // Start is called before the first frame update
    void Start()
    {
        textBox.text = feedbackManager.GetComponent<FeedbackManager>().timeUsed.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        textBox.text = feedbackManager.GetComponent<FeedbackManager>().timeUsed.ToString();
    }
    
}
