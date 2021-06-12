using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PomMovement ActivePoms;
    private Animator currentAnimator;

    [SerializeField] private InputManager _inputManager = default;
    // Start is called before the first frame update
    void Start()
    {
        _inputManager.leftEvent += AttemptMoveLeft;
        _inputManager.rightEvent += AttemptMoveRight;
        _inputManager.flipEvent += Flip;
    }

    private void Flip()
    {
        ActivePoms.DoFlip();
    }

    private void AttemptMoveLeft()
    {
        ActivePoms.TryMoveLeft();
    }

    private void AttemptMoveRight()
    {
        ActivePoms.TryMoveRight();
    }
}
