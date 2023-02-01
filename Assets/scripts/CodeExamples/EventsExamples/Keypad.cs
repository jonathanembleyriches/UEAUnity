using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : MonoBehaviour
{
    // a event is a message sent by an object to signal the occurence of an action
    // a delegate is type that holds a reference to a method.

    // define an event that represents the moment a keypad is unlocked
    public delegate void UnlockHandler();

    // use delegate to define event
    // action verb in the past tense is common naming scheme
    public event UnlockHandler Unlocked;

    public void InputCodeCorrect()
    {
        // this is called the null condition operator "?."
        Unlocked?.Invoke();
    }
}