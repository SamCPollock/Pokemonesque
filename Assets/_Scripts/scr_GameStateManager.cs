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
        GameObject.FindObjectOfType<scr_MusicManager>().PlaySong(0);
    }

    public void SetEncounterState()
    {
        OverworldState.SetActive(false);
        EncounterState.SetActive(true);
        EncounterState.GetComponent<scr_EnemySpawner>().SetUpEnemy();
        GameObject.FindObjectOfType<scr_MusicManager>().PlaySong(1);

    }
}
