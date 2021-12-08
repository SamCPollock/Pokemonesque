using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICharacter : MonoBehaviour
{
    public so_Ability[] abilities;
    public abstract void TakeTurn();


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
