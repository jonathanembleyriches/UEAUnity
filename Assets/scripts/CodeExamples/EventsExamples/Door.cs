using UnityEngine;

public class Door : MonoBehaviour
{
    public void Open()
    {
        // Opens the door
    }
}

public class KeypadDoor : Door
{
    private Keypad keypad;

    private void OnEnable()
    {
        // The open method will now be called when event fires.
        keypad.Unlocked += Open;
    }

    private void OnDisable()
    {
        keypad.Unlocked -= Open;
    }
}