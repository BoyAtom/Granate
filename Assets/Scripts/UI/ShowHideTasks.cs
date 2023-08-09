using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowHideTasks : MonoBehaviour
{
    public Animator taskAnimator;
    public GameObject taskField;
    bool shown_task = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ChangeTaskState();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            string text = Random.Range(1, 100).ToString();
            SetTaskText(text);
        }
    }

    public void SetTaskText(string textForTask)
    {
        taskField.GetComponent<TextMeshProUGUI>().text = textForTask;
    }

    public void ChangeTaskState()
    {
        if (shown_task) StartFlowOut();
        else StartFlowIn();
    }

    private void StartFlowIn()
    {
        shown_task = !shown_task;
        taskAnimator.SetTrigger("StartFlowIn");
    }

    private void StartFlowOut()
    {
        shown_task = !shown_task;
        taskAnimator.SetTrigger("StartFlowOut");
    }
}
