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
        _inputManager.flipEvent += Flip;
    }

    private void Flip()
    {
        ActivePoms.DoFlip();
    }

    private void AttemptMoveLeft()
    {
        
        throw new System.NotImplementedException();
    }
}
