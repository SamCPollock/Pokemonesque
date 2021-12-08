using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "AbilitySystem/Enemy")]

public class so_Enemy : ScriptableObject
{
    public new string name;
    public float maxHealth;
    public so_Ability[] abilities;
    public Sprite sprite;

    public List <int> deck;

}
