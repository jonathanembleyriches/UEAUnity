using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBInteractions : MonoBehaviour
{
    [SerializeField] private float m_pushForce = 10f;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;
        if (rb != null && !rb.isKinematic)
        {
            rb.velocity = hit.moveDirection * m_pushForce;
        }
    }
}