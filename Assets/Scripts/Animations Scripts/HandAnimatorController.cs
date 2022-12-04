using Magic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimatorController : MonoBehaviour
{
    private Animator _handAnimator;
    private readonly int _meteorInvoke = Animator.StringToHash("InvokeMeteor");
    private readonly int _elementInvoke = Animator.StringToHash("InvokeElement");

    void Start()
    {
        _handAnimator = GetComponent<Animator>();   
    }

    public void RandomSpellAnimation()
    {
        _handAnimator.SetTrigger(_meteorInvoke);
    }
    public void ReproduceElementInvokeAnimation(Elements element)
    {
        _handAnimator.SetTrigger(_elementInvoke);
    }
}
