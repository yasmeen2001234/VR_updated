using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private InputActionReference move;
    [SerializeField] private Animator animator;
    private PhotonView m_PhotonView;

    private void OnEnable()
    {

        move.action.started += AnimateLegs;
        move.action.canceled += StopAnimation;
    }

    private void OnDisable()
    {
        move.action.started -= AnimateLegs;
        move.action.canceled -= StopAnimation;
    }

    private void StopAnimation(InputAction.CallbackContext obj)
    {
        animator.SetBool("isWalking", false);
    }

    private void AnimateLegs(InputAction.CallbackContext obj)
    {
        bool isMovingForward = move.action.ReadValue<Vector2>().y > 0;
        m_PhotonView = GetComponent<PhotonView>();
        if (isMovingForward )
        {
            animator.SetBool("isWalking", true);
            animator.SetFloat("animSpeed", 1);
        }

        else
        {
           
                animator.SetBool("isWalking", true);
                animator.SetFloat("animspeed", -1);
            
        }
    }
}