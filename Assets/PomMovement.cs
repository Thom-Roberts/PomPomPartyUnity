using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PomMovement : MonoBehaviour
{
    [SerializeField]
    private Animator TopPomAnimator = default;
    [SerializeField]
    private Animator BottomPomAnimator = default;
    // Is the Top Pom on top or not?
    private bool Inverted = false;

    private int RotateUpHash;
    private int RotateDownHash;

    private void Awake()
    {
        RotateUpHash = Animator.StringToHash("RotateUp");
        RotateDownHash = Animator.StringToHash("RotateDown");
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
}
