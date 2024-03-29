using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [HideInInspector] public Animator animator;

    [HideInInspector] public bool isMoving;
    [HideInInspector] public bool isLocked;

    public AnimationState charState;
    private Coroutine coroutineLock = null;
    private bool allowedInput = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void TriggerAnimation(string trigger)
    {
        animator.SetInteger("Action", (int)(AnimatorTriggers)System.Enum.Parse(typeof(AnimatorTriggers), trigger));
        animator.SetTrigger("Trigger");
    }

    public void ChangeCharacterState(float waitTime, AnimationState state)
    {
        StartCoroutine(_ChangeCharacterState(waitTime, state));
    }

    private IEnumerator _ChangeCharacterState(float waitTime, AnimationState state)
    {
        yield return new WaitForSeconds(waitTime);
        charState = state;
    }

    public void LockMovement(float locktime)
    {
        if (coroutineLock != null)
        {
            StopCoroutine(coroutineLock);
        }
        coroutineLock = StartCoroutine(_LockMovement(locktime));
    }

    private IEnumerator _LockMovement(float locktime)
    {
        allowedInput = false;
        isLocked = true;
        animator.applyRootMotion = true;
        if (locktime != -1f)
        {
            yield return new WaitForSeconds(locktime);
            isLocked = false;
            animator.applyRootMotion = false;
            allowedInput = true;
        }
    }
    
}
