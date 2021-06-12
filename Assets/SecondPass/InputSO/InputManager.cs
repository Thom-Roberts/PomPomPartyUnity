using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputManager", menuName ="Game/Inputs")]
public class InputManager : ScriptableObject, PomPomParty.IPlayerActions
{
    public event UnityAction leftEvent;
    public event UnityAction rightEvent;
    public event UnityAction<InputAction.CallbackContext> downEvent;
    public event UnityAction debugEvent;
    public event UnityAction flipEvent;

    private PomPomParty inputs;

    private void OnEnable() {
        if(inputs == null)
        {
            inputs = new PomPomParty();
            inputs.Player.SetCallbacks(this);
        }

        inputs.Player.Enable();
    }

    public void OnLeft(InputAction.CallbackContext context)
    {
        if(context.performed)
            leftEvent?.Invoke();
    }

    public void OnRight(InputAction.CallbackContext context)
    {
        if(context.performed)
            rightEvent?.Invoke();
    }

    public void OnDown(InputAction.CallbackContext context)
    {
        downEvent?.Invoke(context);
    }

    public void OnDebug(InputAction.CallbackContext context)
    {
        if(context.performed)
            debugEvent?.Invoke();
    }

    public void OnFlip(InputAction.CallbackContext context)
    {
        if (context.performed)
            flipEvent?.Invoke();
    }
}
