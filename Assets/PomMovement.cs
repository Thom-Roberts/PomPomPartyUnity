using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PomMovement : MonoBehaviour
{
    [SerializeField]
    private Animator TopPomAnimator = default;
    [SerializeField]
    private Animator BottomPomAnimator = default;

    private Transform TopPomTransform = default;
    private Transform BottomPomTransform = default;

    // Is the Top Pom on top or not?
    private bool Inverted = false;
    private float ShiftDistance = 0.5f;

    private int LandingHash;
    private int RotateUpHash;
    private int RotateDownHash;

    private void Awake()
    {
        LandingHash = Animator.StringToHash("Landed");
        RotateUpHash = Animator.StringToHash("RotateUp");
        RotateDownHash = Animator.StringToHash("RotateDown");

        TopPomTransform = TopPomAnimator.transform;
        BottomPomTransform = BottomPomAnimator.transform;
    }

    public void TryMoveLeft()
    {
        Vector3 raycastOrigin = Inverted ? TopPomTransform.position : BottomPomTransform.position;
        if(!Physics2D.Raycast(raycastOrigin, Vector2.left, 0.5f))
            transform.position = new Vector2(transform.position.x - ShiftDistance, transform.position.y);
    }

    public void TryMoveRight()
    {
        Vector3 raycastOrigin = Inverted ? TopPomTransform.position : BottomPomTransform.position;
        if (!Physics2D.Raycast(raycastOrigin, Vector2.right, 0.5f))
            transform.position = new Vector2(transform.position.x + ShiftDistance, transform.position.y);
    }

    public void DoFlip()
    {
        if(Inverted)
        {
            TopPomAnimator.SetTrigger(RotateUpHash);
            BottomPomAnimator.SetTrigger(RotateDownHash);
        }
        else
        {
            TopPomAnimator.SetTrigger(RotateDownHash);
            BottomPomAnimator.SetTrigger(RotateUpHash);
        }

        Inverted = !Inverted;
    }

    public void DoLand()
    {
        TopPomAnimator.SetTrigger(LandingHash);
        BottomPomAnimator.SetTrigger(LandingHash);
        TopPomTransform.gameObject.layer = LayerMask.NameToLayer("Default");
        BottomPomTransform.gameObject.layer = LayerMask.NameToLayer("Default");
    }
}
