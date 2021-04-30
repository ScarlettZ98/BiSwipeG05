using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.ComponentModel;
using UnityEngine.UI;

public class FeedbackManager : MonoBehaviour
{
    public Text dialog;

    public int currentStage;

    public GameObject NextStageButton;

    private bool isRecoding;

    private float learningTimer;
    // is the timer running
    public bool timerRunning;

    //tracking time for current challenge
    private float currentTimer;

    //introduction for each stage
    private List<string> dialogs = new List<string>();

    // track all time use in each challenge
    private List<float> Timers = new List<float>();

    // challenges
    public List<GameObject> targets;

    void Awake()
    {
        currentStage = 0;

        learningTimer = 0.0f;

        isRecoding = false;

        timerRunning = false;

        currentTimer = 0.0f;

        // adding introductions
        dialogs.Add("C2: Same Screen, different tab");//
        dialogs.Add("C3: Different Screen, same tab");//
        dialogs.Add("C4: Different Screen, different tab");
        dialogs.Add("C5: Result recorded.");

        dialog.text = "Preparation";
    }

    // Update is called once per frame
    void Update()
    {
        if (learningTimer < 60.0f)
        {
            learningTimer += Time.deltaTime;
        } else
        {
            endLearning();
        }

        //stageManager();
        if (timerRunning)
        {
            currentTimer += Time.deltaTime;
        }
    }

    IEnumerator scriptLoopBody() 
    {
        // Start C1
        dialog.text = "C1: Same Screen, Same tab";
        yield return new WaitForSeconds(5);
        // C1.0
        dialog.text = "Screen 0, Vertical";
        GameObject target = targets[0];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;
        // C1.1
        target = targets[1];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;
        // C1.2
        target = targets[2];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;
        // C1.3
        target = targets[3];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;
        // C1.4
        target = targets[4];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;
        // C1.5
        target = targets[5];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;
        // C1.6
        target = targets[6];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;
        // C1.7
        target = targets[7];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;
        // C1.8
        target = targets[8];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;
        // C1.9
        target = targets[9];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;

        // Start C2
        dialog.text = "C2: Same Screen, different tab";
        yield return new WaitForSeconds(5);
        // C2.0
        dialog.text = "Screen 0, Vertical";
        target = targets[10];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;
        // C2.1
        dialog.text = "Screen 0, Horizontal";
        target = targets[11];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;
        // C2.2
        dialog.text = "Screen 0, Vertical";
        target = targets[12];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;
        // C2.3
        dialog.text = "Screen 0, Horizontal";
        target = targets[13];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;
        // C2.4
        dialog.text = "Screen 0, Vertical";
        target = targets[14];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;
        // C2.5
        dialog.text = "Screen 0, Horizontal";
        target = targets[15];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;
        // C2.6
        dialog.text = "Screen 0, Vertical";
        target = targets[16];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;
        // C2.7
        dialog.text = "Screen 0, Horizontal";
        target = targets[17];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;
        // C2.8
        dialog.text = "Screen 0, Vertical";
        target = targets[18];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;
        // C2.9
        dialog.text = "Screen 0, Horizontal";
        target = targets[19];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;

        // Start C3
        dialog.text = "C3: Different Screen, same tab";
        yield return new WaitForSeconds(5);
        // C3.0
        dialog.text = "Screen 0, Horizontal";
        target = targets[20];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;
        // C3.1
        dialog.text = "Screen 1, Horizontal";
        target = targets[21];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;
        // C3.2
        dialog.text = "Screen 0, Horizontal";
        target = targets[22];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;
        // C3.3
        dialog.text = "Screen 1, Horizontal";
        target = targets[23];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;
        // C3.4
        dialog.text = "Screen 0, Horizontal";
        target = targets[24];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;
        // C3.5
        dialog.text = "Screen 1, Horizontal";
        target = targets[25];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;
        // C3.6
        dialog.text = "Screen 0, Horizontal";
        target = targets[26];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;
        // C3.7
        dialog.text = "Screen 1, Horizontal";
        target = targets[27];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;
        // C3.8
        dialog.text = "Screen 0, Horizontal";
        target = targets[28];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;
        // C3.9
        dialog.text = "Screen 1, Horizontal";
        target = targets[29];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;

        // Start C4
        dialog.text = "C4: Different Screen, different tab";
        yield return new WaitForSeconds(5);

        // C4.0
        dialog.text = "Screen 1, Horizontal";
        target = targets[30];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;
        // C4.1
        dialog.text = "Screen 0, Vertical";
        target = targets[31];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;
        // C4.2
        dialog.text = "Screen 1, Vertical";
        target = targets[32];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;
        // C4.3
        dialog.text = "Screen 0, Horizontal";
        target = targets[33];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;
        // C4.4
        dialog.text = "Screen 1, Horizontal";
        target = targets[34];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;
        // C4.5
        dialog.text = "Screen 0, Vertical";
        target = targets[35];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;
        // C4.6
        dialog.text = "Screen 1, Vertical";
        target = targets[36];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;
        // C4.7
        dialog.text = "Screen 0, Horizontal";
        target = targets[37];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;
        // C4.8
        dialog.text = "Screen 1, Horizontal";
        target = targets[38];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;
        // C4.9
        dialog.text = "Screen 0, Vertical";
        target = targets[39];
        target.GetComponent<SmallButtonBehavior>().getSelected();
        timerRunning = true;
        yield return new WaitUntil(() => (!timerRunning));
        target.GetComponent<SmallButtonBehavior>().getDeselected();
        Timers.Add(currentTimer);
        currentTimer = 0.0f;

        // Serialize result
        dialog.text = "Generating and sending records";
        string body = "";
        foreach(float f in Timers)
        {
            body = body + f.ToString() + ",";
        }
        // send result
        SimpleEmailSender.emailSettings.STMPClient = "smtp-mail.outlook.com";
        SimpleEmailSender.emailSettings.SMTPPort = 587;
        SimpleEmailSender.emailSettings.UserName = "biswipe2021@outlook.com";
        SimpleEmailSender.emailSettings.UserPass = "i8e0o$4PB&Yz";

        SimpleEmailSender.Send("shilingz98@gmail.com", "Biswipe result", body, "", SendCompletedCallback);
    }

    private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
    {
        if (e.Cancelled || e.Error != null)
        {
            dialog.text = "Error in sending";
        }
        else
        {
            dialog.text = "Success";
        }
    }


    public void endLearning()
    {
        if (!isRecoding)
        {
            isRecoding = true;
            NextStageButton.SetActive(false);
            currentStage++;
            Debug.Log("switch");
            StartCoroutine(scriptLoopBody());   
        }
    }

}
