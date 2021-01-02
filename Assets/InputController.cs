using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public UnityEvent<bool> downPressed;

    public void OnLeft()
    {
        print("Left pressed successfully");
        
        Vector3 raycastPosition = transform.position;
        // Want to project from the bottom
        raycastPosition.y -=  0.5f;
       
        Debug.DrawRay(raycastPosition, new Vector3(-1, 0, 0), Color.green, 1f);
        if (Physics.Raycast(raycastPosition, new Vector3(-1, 0, 0), 1f))
        {
            print("Cannot move left");
        }
        else
        {
            transform.Translate(new Vector3(-1, 0, 0));
            print("Can move left");
        }
    }

    public void OnRight()
    {
        print("Right pressed successfully");

        Vector3 raycastPosition = transform.position;
        // Want to project from the bottom
        raycastPosition.y -= 0.5f;

        Debug.DrawRay(raycastPosition, new Vector3(1, 0, 0), Color.green, 1f);
        if (Physics.Raycast(raycastPosition, new Vector3(1, 0, 0), 1f))
        {
            print("Cannot move right");
        }
        else
        {
            transform.Translate(new Vector3(1, 0, 0));
            print("Can move right");
        }
    }

    public void OnDown(InputValue value)
    {
        downPressed?.Invoke(value.isPressed);
        if (value.isPressed)
            print("Down pressed successfully");
        else
            print("Down was released");
    }
}
