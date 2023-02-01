using System;
using UnityEngine;

public class Referencing : MonoBehaviour
{
    public Transform m_gameObject_transform;

    private void Awake()
    {
        m_gameObject_transform = GameObject.FindGameObjectWithTag("ExampleTag").GetComponent<Transform>();
    }

    private void Update()
    {
        m_gameObject_transform.position = Vector3.zero;
    }
}