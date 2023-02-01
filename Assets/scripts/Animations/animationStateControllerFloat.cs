using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateControllerFloat : MonoBehaviour
{
    public Animator m_animtaor;
    public float m_velocity = 0f;
    public float m_accel = .1f;
    public float m_deccel = .1f;

    private int m_velocityHash;

    // Start is called before the first frame update
    private void Start()
    {
        m_animtaor = GetComponent<Animator>();
        m_velocityHash = Animator.StringToHash("playerVelocity");
    }

    // Update is called once per frame
    private void Update()
    {
        bool forwardPressed = Input.GetKey("w");

        if (forwardPressed && m_velocity < 1.0f)
        {
            m_velocity += Time.deltaTime * m_accel;
        }
        if (!forwardPressed && m_velocity >= 0f)
        {
            m_velocity -= Time.deltaTime * m_deccel;
        }
        if (m_velocity < 0.0f) m_velocity = 0.0f;
        m_animtaor.SetFloat(m_velocityHash, m_velocity);
    }
}