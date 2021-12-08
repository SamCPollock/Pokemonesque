using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_EncounterUI : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI encounterText;

    [SerializeField]
    private GameObject abilityPanel;

    [SerializeField]
    float timeBetweenCharacters = 0.1f;

    // A reference to keep track of the coroutine
    private IEnumerator animateTextCoroutineRef = null;

    void Start()
    {

        animateTextCoroutineRef = AnimateTextCoroutine("You have encountered an opponent.");
        // Animate some text to say what you encountered
//        StartCoroutine(animateTextCoroutineRef);


    }

    public IEnumerator AnimateTextCoroutine(string message)
    {
        abilityPanel.SetActive(false);


        encounterText.text = "";
        for (int currentCharacter = 0; currentCharacter < message.Length; currentCharacter++)
        {
            encounterText.text += message[currentCharacter];
            yield return new WaitForSeconds(timeBetweenCharacters);
        }
        abilityPanel.SetActive(true);

        yield return new WaitForSeconds(2);
        encounterText.text = "";
        animateTextCoroutineRef = null;    // set the reference back to null so if we want we can check if it is running. 
    }
}
