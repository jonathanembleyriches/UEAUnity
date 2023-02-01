using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Content/Game Item")]
public class GameItem : ScriptableObject
{
    public Sprite icon;
    public GameItemSlot slot;
    public GameItemEffect[] effects;

    public bool OnEquip(GameCharacter c)
    {
        for (int i = 0; i < effects.Length; ++i)
        {
            effects[i].OnEquip(c);
        }
        return true;
    }

    public bool onRemove(GameCharacter c)
    {
        for (int i = 0; i < effects.Length; ++i)
        {
            effects[i].OnEquip(c);
        }
        return true;
    }
}