using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public enum AnimationState
    {
        Idle,
        Fishing
    }

    public enum AnimatorTriggers
    {
        NoAction = 0,
        FishingCast = 20,
        FishingReel = 28,
        FishingFinish = 29
    }
