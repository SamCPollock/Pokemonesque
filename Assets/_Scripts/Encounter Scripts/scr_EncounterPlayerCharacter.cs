using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_EncounterPlayerCharacter : ICharacter
{

    private GameObject abilitiesPanel;
    public GameObject abilityButtonPrefab;
    public scr_EncounterUI encounterUI;

    public override void TakeTurn()
    {
        scr_EncounterHandler.PassTurn();
    }

    // Start is called before the first frame update
    void Start()
    {
        abilitiesPanel = GameObject.Find("AbilitiesPanel");
        encounterUI = GameObject.Find("State_Encounter").GetComponent<scr_EncounterUI>();

        foreach(so_Ability ability in abilities)
        {
            GameObject newButton = Instantiate(abilityButtonPrefab, abilitiesPanel.transform);
            newButton.GetComponentInChildren<Text>().text = ability.name;
            newButton.GetComponent<Button>().onClick.AddListener(() => UseAbility(ability));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseAbility(so_Ability abilityToUse)
    {
        // TODO: Make this call the Coroutine in EncounterUI to display the abilityText on screen. 
        //encounterUI.StartCoroutine(AnimateTextCoroutine(abilityToUse.abilityText));

        if (scr_EncounterHandler.isPlayerTurn)
        {
            StartCoroutine(encounterUI.AnimateTextCoroutine(abilityToUse.abilityText));
            //yield return new WaitForSeconds(4);
            TakeTurn();
        }
    }
}
