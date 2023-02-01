using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsTestForces : MonoBehaviour
{
    [SerializeField] private float m_radius = 3f;
    [SerializeField] private float m_forceAmount = 3f;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Collider[] hitObjs = Physics.OverlapSphere(transform.position, m_radius, 1 << 8);
            foreach (var obj in hitObjs)
            {
                obj.GetComponent<Rigidbody>().AddExplosionForce(m_forceAmount, transform.position, m_radius, 1f, ForceMode.Impulse);
            }
        }
    }
}