using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class WeaponIK : MonoBehaviour
{
    protected Animator animator;

    public Transform rightgrip;
    public Transform leftgrip;
    [Range(0, 1)]
    public float weight = 1.0f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnAnimatorIK()
    {
        set_right_hand();
        set_left_hand();
    }

    void set_right_hand()
    {
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, weight);
        animator.SetIKRotationWeight(AvatarIKGoal.RightHand, weight);
        animator.SetIKPosition(AvatarIKGoal.RightHand, rightgrip.position);
        animator.SetIKRotation(AvatarIKGoal.RightHand, rightgrip.rotation);
    }

    void set_left_hand()
    {
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, weight);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, weight);
        animator.SetIKPosition(AvatarIKGoal.LeftHand, leftgrip.position);
        animator.SetIKRotation(AvatarIKGoal.LeftHand, leftgrip.rotation);
    }
}
