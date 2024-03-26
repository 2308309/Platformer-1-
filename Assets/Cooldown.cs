using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Cooldown : MonoBehaviour
{
    public enum Progress
    {
        Ready, //0
        Started, //1
        InProgress, //2
        Finished //3
    }
    
    public Progress CurrentProgress = Progress.Ready;
    public float TimeLeft
    {
        get { return _currentDuration; }
    }
    public bool IsOnCooldown
    {
        get { return _isOnCooldown; }
    }

    public float Duration = 1.0f;

    private float _currentDuration = 0f;
    private bool _isOnCooldown = false;

    private Coroutine _coroutine;

    public void StartCooldown()
    {
        if (CurrentProgress is Progress.Started or Progress.Inprogress)
            return;

        _coroutine = CoroutineHost.Instance.StartCoroutine(DoCooldown());
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
