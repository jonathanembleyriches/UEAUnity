using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        ToggleLamp();
    }

    public void ToggleLamp()
    {
        // Turn lamp on or off based on state.
    }
}