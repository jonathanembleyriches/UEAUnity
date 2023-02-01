using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    private Action<Shape> m_killAction;
    public ParticleSystem m_particleSystem;
    public Vector3 m_collidePos;

    public void Awake()
    {
        m_particleSystem = gameObject.GetComponent<ParticleSystem>();
    }

    public void Init(Action<Shape> killAction)
    {
        m_killAction = killAction;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //m_killAction(this);
        if (collision.transform.CompareTag("Ground"))
        {
            m_collidePos = collision.GetContact(0).point;//collision.transform.position;
            m_killAction(this);
        }
    }
}