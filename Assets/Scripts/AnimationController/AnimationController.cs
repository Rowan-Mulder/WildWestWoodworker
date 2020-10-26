﻿using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator animator;
    //Referentie naar alle script objecten om animaties mee te kunnen bepalen
    public string currentState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeAnimationState(string newState)
    {
        if (currentState != newState)
        {
            animator.Play(newState);

            currentState = newState;
        }
    }
}