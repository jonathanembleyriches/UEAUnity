using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolingSpawner : MonoBehaviour
{
    [SerializeField] private Shape m_prefab;
    [SerializeField] private int m_spawnAmount = 20;
    private ObjectPool<Shape> m_objPool;
    [SerializeField] private int m_defaultCapacity = 100;
    [SerializeField] private int m_maxCapacity = 800;

    public ParticleSystem particleSystem;

    private void Awake()
    {
    }

    // Start is called before the first frame update
    private void Start()
    {
        m_objPool = new ObjectPool<Shape>(() =>
        {
            return Instantiate(m_prefab, this.transform);
        },
        //shape => Die(shape)
        shape => { shape.gameObject.SetActive(true); }
        , shape => StartCoroutine(Di2e(shape))
    //{
    //  shape.m_particleSystem.Play();
    // shape.gameObject.SetActive(false);
    //    }
    , shape =>
        {
            Destroy(shape);
        }, false, m_defaultCapacity, m_maxCapacity);

        InvokeRepeating(nameof(Spawn), .2f, .2f);
    }

    private IEnumerator Di2e(Shape shape)
    {
        //shape.m_particleSystem.transform = shape.transform;
        shape.GetComponent<Renderer>().enabled = false;
        shape.m_particleSystem.transform.position = shape.m_collidePos;

        shape.m_particleSystem.transform.rotation = Quaternion.Euler(-90, 0, 0);
        shape.m_particleSystem.Play();
        while (shape.m_particleSystem.isPlaying)
            yield return null;
        shape.GetComponent<Renderer>().enabled = true;
        shape.gameObject.SetActive(false);
    }

    private void Spawn()
    {
        for (int i = 0; i < m_spawnAmount; i++)
        {
            Shape shape = m_objPool.Get();
            shape.transform.position = transform.position + UnityEngine.Random.insideUnitSphere;
            shape.Init(KillShape);
        }
    }

    private void KillShape(Shape shape)
    {
        //particleSystem.transform.position = shape.transform.position;
        //particleSystem.Play();
        m_objPool.Release(shape);
    }
}