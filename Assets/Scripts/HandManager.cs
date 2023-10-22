using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.Events;
using System;
using TMPro;

public class HandManager : MonoBehaviour
{
    private bool leftHandRecording = false;
    private bool rightHandRecording = false;
    private bool leftHandCapturing = false;
    private bool rightHandCapturing = false;
    public bool IsRecording = false;
    public bool IsCapturing = false;

    public TMP_Text TMPtext;

UnityEvent recording;
    UnityEvent capturing;

    void Start()
    {
        if (recording == null)
            recording = new UnityEvent();

        if (capturing == null)
            capturing = new UnityEvent();

        recording.AddListener(Recording);
        capturing.AddListener(Capturing);
    }

    
    // Recording
    public void LeftHandRecording()
    {
        leftHandRecording = true;
        recording.Invoke();
    }

    public void RightHandRecording()
    {
        rightHandRecording = true;
        recording.Invoke();
    }

    public void LeftHandNotRecording()
    {
        leftHandRecording = false;
    }

    public void RightHandNotRecording()
    {
        rightHandRecording = false;
    }

    //Capturing
    public void LeftHandCapturing()
    {
        leftHandCapturing = true;
        capturing.Invoke();
    }

    public void RightHandCapturing()
    {
        rightHandCapturing = true;
        capturing.Invoke();
    }

    public void LeftHandNotCapturing()
    {
        leftHandCapturing = false;
    }

    public void RightHandNotCapturing()
    {
        rightHandCapturing = false;
    }

    private void Recording()
    {
        if (leftHandRecording && rightHandRecording && IsRecording == false)
        {
            IsRecording = true;
            Debug.Log("Recording!");
            TMPtext.text = "Recording!";
        } else
        {
            IsRecording = false;
            Debug.Log($"Not recording! leftHandRecording: {leftHandRecording} rightHandRecording: {rightHandRecording}");
            TMPtext.text = $"Not recording! leftHandRecording: {leftHandRecording} rightHandRecording: {rightHandRecording}";
        }
    }

    private void Capturing()
    {
        if (leftHandCapturing && rightHandCapturing && IsRecording)
        {
            IsCapturing = true;
            IsRecording = false;
            Debug.Log("Capturing!");
            TMPtext.text = "Capturing!";
        }
        else
        {
            IsCapturing = false;
            Debug.Log($"Not Capturing! leftHandCapturing: {leftHandCapturing} rightHandCapturing: {rightHandCapturing}" +
                $"\nleftHandRecording: {leftHandRecording} rightHandRecording: {rightHandRecording}");
            TMPtext.text = $"Not Capturing! leftHandCapturing: {leftHandCapturing} rightHandCapturing: {rightHandCapturing}" +
                $"\nleftHandRecording: {leftHandRecording} rightHandRecording: {rightHandRecording}";
        }
    }
}
