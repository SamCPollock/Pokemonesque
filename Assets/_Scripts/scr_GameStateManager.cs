using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_GameStateManager : MonoBehaviour
{
    public GameObject OverworldState;
    public GameObject EncounterState;

  

  public void SetOverworldState()
    {
        OverworldState.SetActive(true);
        EncounterState.SetActive(false);
    }

    public void SetEncounterState()
    {
        OverworldState.SetActive(false);
        EncounterState.SetActive(true);
        EncounterState.GetComponent<scr_EnemySpawner>().SetUpEnemy();
    }
}
