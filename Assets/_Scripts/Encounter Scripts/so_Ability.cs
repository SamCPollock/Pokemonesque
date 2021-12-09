using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ability", menuName = "AbilitySystem/Ability")]
public class so_Ability : ScriptableObject
{
    public new string name;
    public new string description;

    public string abilityText;
    public so_IEffect[] effects;
}
