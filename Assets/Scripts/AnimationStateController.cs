using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    private Animator animator;

    private int isWalkingHash;
    private bool isWalking;

    private int isJumpingHash;
    private bool isJumping;

    private int isInteractingHash;
    private bool isInteracting;

    void Start()
    {
        animator = GetComponent<Animator>();

        isWalkingHash = Animator.StringToHash("isWalking");
        isJumpingHash = Animator.StringToHash("isJumping");
        isInteractingHash = Animator.StringToHash("isInteracting");
    }

    void Update()
    {
        Walking();
        Jumping();
        Interacting();
    }

    private void Walking()
    {
        isWalking = animator.GetBool(isWalkingHash);

        bool forward = Input.GetKey(KeyCode.W);

        if (!isWalking && forward)
        {
            animator.SetBool(isWalkingHash, true);
        }

        if (isWalking && !forward)
        {
            animator.SetBool(isWalkingHash, false);
        }
    }

    private void Jumping()
    {
        isJumping = animator.GetBool(isJumpingHash);

        bool jump = Input.GetKey(KeyCode.Space);

        if (!isJumping && jump)
        {
            animator.SetBool(isJumpingHash, true);
        }

        if (isJumping && !jump)
        {
            animator.SetBool(isJumpingHash, false);
        }
    }

    private void Interacting()
    {
        isInteracting = animator.GetBool(isInteractingHash);

        bool interact = Input.GetKey(KeyCode.F);

        if (!isInteracting && interact)
        {
            animator.SetBool(isInteractingHash, true);
        }

        if (isInteracting && !interact)
        {
            animator.SetBool(isInteractingHash, false);
        }
    }
}
