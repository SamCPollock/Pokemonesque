using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class scr_MouseOver : MonoBehaviour
{
    public string mouseOverText;
    public TextMeshProUGUI text;

    private void Start()
    {
        text.text = mouseOverText;
        text.gameObject.SetActive(false);
    }

    public void ShowText()
    {
        text.gameObject.SetActive(true);
        Debug.Log("MOUSE OVER");
    }

    public void HideText()
    {
        text.gameObject.SetActive(false);

        Debug.Log("MOUSE EXIT");

    }
}
