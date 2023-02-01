using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateControllerBool : MonoBehaviour
{
    public Animator m_animtaor;
    private bool m_isWalking = false;
    private int m_isWalkingHash;

    // Start is called before the first frame update
    private void Start()
    {
        m_animtaor = GetComponent<Animator>();
        m_isWalkingHash = Animator.StringToHash("isWalking");
    }

    // Update is called once per frame
    private void Update()
    {
        bool isWalkking = m_animtaor.GetBool(m_isWalkingHash);
        bool forwardPressed = Input.GetKey("w");

        if (!isWalkking && forwardPressed)
        {
            m_animtaor.SetBool(m_isWalkingHash, true);
        }
        if (isWalkking && !forwardPressed)
        {
            m_animtaor.SetBool(m_isWalkingHash, false);
        }
    }
}