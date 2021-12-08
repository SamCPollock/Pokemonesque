using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ability", menuName = "AbilitySystem/Ability")]
public class so_Ability : ScriptableObject
{
    public new string name;
    public string abilityText;
    public so_IEffect[] effects;
}
