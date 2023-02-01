using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Content/Health Config")]
public class NPCHealthConfig : ScriptableObject
{
    public int MaxHealth;
    public int HealthThreshold;
}