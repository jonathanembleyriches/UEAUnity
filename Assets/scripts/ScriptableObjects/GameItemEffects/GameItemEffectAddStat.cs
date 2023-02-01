using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Content/GameItemEffect Add Stat")]
public class GameItemEffectAddStat : GameItemEffect
{
    public GameStat stat;
    public int amountToAdd;

    public override void OnEquip(GameCharacter c)
    {
        c.AddStat(stat, amountToAdd);
    }

    public override void OnRemove(GameCharacter c)
    {
        c.AddStat(stat, -1 * amountToAdd);
    }
}