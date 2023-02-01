using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCharacter : MonoBehaviour
{
    public NPCHealthConfig m_config;

    public int m_currentHealth = 100;

    public GameItem m_testItem;

    public GameItemSlot m_itemSlotType;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            EquipItem();
        }
    }

    public void AddStat(GameStat gameStat, int amount)
    {
        // do nothing
    }

    public void EquipItem()
    {
        if (m_testItem.slot.Equals(m_itemSlotType))
        {
            Debug.Log("Succesfully equipped item");
        }
        else
        {
            Debug.Log("Failed to equip item, slot is wrong type");
        }
    }
}