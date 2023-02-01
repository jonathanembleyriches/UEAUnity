using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public int m_amount;
    public int m_effectID;
    public Harvestable m_harvestable;
    public int m_cooldown;

    public void Awake()
    {
        m_harvestable = new Harvestable(m_effectID, m_amount);
    }

    public int Harvest()
    {
        if (!m_harvestable.m_isHarvestable) return 0;

        m_harvestable.m_isHarvestable = false;
        this.GetComponent<Renderer>().enabled = false;
        StartCoroutine(RespawnCoroutine());
        return m_harvestable.Harvest();
    }

    private IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSeconds(m_cooldown);
        m_harvestable.Respawn();
        this.GetComponent<Renderer>().enabled = true;
    }
}