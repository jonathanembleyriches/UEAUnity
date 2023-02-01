using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePlayer : MonoBehaviour
{
    public GameObject m_objectToInteract;

    private void Update()
    {
        // Lets pretend we found this object from the player being close
        // and them clicking on it
        GameObject nearestGameObject = m_objectToInteract;
        IInteractable possibleInteractableObject = nearestGameObject.GetComponent<IInteractable>();

        if (possibleInteractableObject != null)
            possibleInteractableObject.Interact();
    }

    public void BadUpdate()
    {
        GameObject nearestGameObject = m_objectToInteract;

        // Every object has a different way to interact
        // we have to test what one it is
        Lamp lamp = nearestGameObject.GetComponent<Lamp>();
        if (lamp != null)
            lamp.ToggleLamp();

        Door door = nearestGameObject.GetComponent<Door>();
        if (door != null)
            door.Open();
    }
}