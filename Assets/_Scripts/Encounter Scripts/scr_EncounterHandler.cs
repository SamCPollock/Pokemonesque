using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_EncounterHandler : MonoBehaviour
{
    public static bool isPlayerTurn = true;
    public static void PassTurn()
    {
        isPlayerTurn = !isPlayerTurn;
    }

}
