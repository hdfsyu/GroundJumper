using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class MotionBlurHotkey : MonoBehaviour
{
    private VolumeProfile volumeProfile;
    private MotionBlur motionBlur;
    private bool hasClicked = false;
    private void Start()
    {
        volumeProfile = GetComponent<Volume>()?.profile;
        if (!volumeProfile) throw new System.NullReferenceException(nameof(VolumeProfile));
        if (!volumeProfile.TryGet(out motionBlur)) throw new System.NullReferenceException(nameof(motionBlur));
    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F7))
        {
            if (hasClicked)
            {
                motionBlur.intensity.Override(0.0f);
                hasClicked = false;
            }else if (!hasClicked)
            {
                motionBlur.intensity.Override(0.3f);
                hasClicked = true;
            }
        }
    }
}
