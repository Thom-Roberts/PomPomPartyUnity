using UnityEngine;
using UnityEngine.InputSystem;

public class PomAnimController : MonoBehaviour
{
    private Animator animator;
    private int LandedHash;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        LandedHash = Animator.StringToHash("Landed");
    }

    public void TriggerLand()
    {
        animator.ResetTrigger(LandedHash);
        animator.SetTrigger(LandedHash);
    }
}
