using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Effect", menuName = "AbilitySystem/Effect")]
public class so_IEffect : ScriptableObject
{
    public int baseDamage;

    public int strengthScaling;

    public int damageRoll;

    public int buff;

    public int debuff;

}
