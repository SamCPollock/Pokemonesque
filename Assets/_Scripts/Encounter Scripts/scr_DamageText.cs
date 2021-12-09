using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scr_DamageText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    private void Start()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        Invoke("HideSelf", 1);
    }


    private void HideSelf()
    {
        gameObject.SetActive(false);
    }

    public void ShowDamage(int damageToShow)
    {
        gameObject.SetActive(true);
        text.text = "-" + damageToShow.ToString();
    }
}
