using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimatorHandler : MonoBehaviour
{


    // Start is called before the first frame update
    //void Start()
    //{
    //    _animator = GetComponent<Animator>();
    //    _movement = transform.parent.GetComponent<Movement>();

    //    _initialScale = transform.localScale;
    //    _flipScale = new Vector3(-_initialScale.x, _initialScale.y, _initialScale.z);
    //}

    // Update is called once per frame
    void Update()
    {
        //HandleFlip();
        UpdateAnimator();
    }

    //void HandleFlip()
    //{
    //    if (_movement == null)
    //        return;

    //    if (_movement.FlipAnim == false)
    //    {
    //        transform.localScale = _initialScale;
    //    }
    //    else
    //    {
    //        transform.localScale = _flipScale;
    //    }

    //    //transform.localScale = _movement.FlipAnim ? _flipScale : _initialScale
    //}

    void UpdateAnimator()
    {
        //if (_movement == null || _animator == null) 
        //    return;

        //_animator.SetBool(name: "IsRunning", _movement.IsRunning);
        //_animator.SetBool(name: "IsJumping", _movement.IsJumping);
        //_animator.SetBool(name: "IsFalling", _movement.IsFalling);
    }

}
