using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent relocate;
    [HideInInspector]
    public UnityEvent speak;
    public Transform CenterEyeOffset;

    public QuadManager quadManager;
    public AudioSource audioSpeak;
    public AudioSource audioCat;

    void Start()
    {
        if (relocate == null)
            relocate = new UnityEvent();
        if (speak == null)
            speak = new UnityEvent();

        relocate.AddListener(Relocating);
        speak.AddListener(Speaking);
    }

    private void Relocating()
    {
        Vector3 position = new Vector3(CenterEyeOffset.position.x + UnityEngine.Random.Range(-1.5f, 1.5f), 
            this.transform.position.y, 
            CenterEyeOffset.position.z + UnityEngine.Random.Range(-1.5f, 1.5f));
        this.transform.position = position;
        audioCat.Play();
        quadManager.aim = false;
    }

    private void Speaking()
    {
        audioSpeak.Play();
    }
}
