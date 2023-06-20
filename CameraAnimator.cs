using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimator : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }
   
    public void Playanimator()
    {
        _animator.enabled = true;
        _animator.SetBool("GoToSetting", true);
    }

    void PauseAnimationEvent()
    {
        _animator.enabled = false;
        _animator.SetBool("GoToSetting", false);
    }

    public void Back()
    {
        _animator.enabled = true;
        _animator.SetBool("GoBackToMenu", true);
    }
}
