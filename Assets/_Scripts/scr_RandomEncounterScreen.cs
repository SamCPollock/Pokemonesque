using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_RandomEncounterScreen : MonoBehaviour
{
    public GameObject overworld;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            overworld.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
