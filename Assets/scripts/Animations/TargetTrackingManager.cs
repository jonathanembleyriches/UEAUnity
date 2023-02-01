using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class TargetTrackingManager : MonoBehaviour
{
    private MultiAimConstraint m_aimConstrain;
    [SerializeField] private float m_range = 3f;
    public Transform m_lookAtTransform;

    private void Start()
    {
        m_aimConstrain = this.GetComponent<MultiAimConstraint>();
    }

    private void Update()
    {
        float strength = 0;
        float currentWeight = m_aimConstrain.data.sourceObjects.GetWeight(0);
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, m_range, 1 << 6);

        foreach (var hitCollider in hitColliders)
        {
            // Move the look at transform to colliders transform.
            m_lookAtTransform.position = hitCollider.transform.position;
            float dist = Vector3.Distance(transform.position, hitCollider.transform.position);
            Debug.Log(dist);
            strength = dist / m_range;
        }

        if (strength != currentWeight)
        {
            WeightedTransformArray weightArray = m_aimConstrain.data.sourceObjects;
            weightArray.SetWeight(0, strength);
            m_aimConstrain.data.sourceObjects = weightArray;
            m_aimConstrain.weight = strength;
        }
    }
}