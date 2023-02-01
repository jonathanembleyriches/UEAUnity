using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameItemEffect : ScriptableObject
{
    public abstract void OnEquip(GameCharacter c);

    public abstract void OnRemove(GameCharacter c);
}