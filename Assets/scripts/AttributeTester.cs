using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Adds this component to the obj when this script is attached.
[RequireComponent(typeof(Rigidbody))]
public class AttributeTester : MonoBehaviour
{
    [Header("Stats")]
    public float m_health = 100;

    // Much better way, private and can edit in inspector.
    [SerializeField] private float m_damage = 1f;

    [Range(1, 10)]
    [SerializeField] private int m_damageRange;

    //Split the sections up.
    [Space(10)]
    [Header("Character Information")]
    // Big area for typing a string
    [TextArea(minLines: 2, maxLines: 4)]
    [SerializeField] private string m_objectBio;
}