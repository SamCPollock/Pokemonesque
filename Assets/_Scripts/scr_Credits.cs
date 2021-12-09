using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Credits : MonoBehaviour
{
    [SerializeField]
    GameObject creditsCanvas;
  public void ShowCredits()
    {
        creditsCanvas.SetActive(true);
    }

    public void HideCredits()
    {
        creditsCanvas.SetActive(false);
    }
}
