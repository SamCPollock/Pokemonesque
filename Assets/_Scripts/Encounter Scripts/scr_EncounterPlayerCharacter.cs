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

        UpdateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseAbility(so_Ability abilityToUse)
    {

        if (scr_EncounterHandler.isPlayerTurn)
        {
            StartCoroutine(encounterUI.AnimateTextCoroutine(abilityToUse.abilityText));
            //yield return new WaitForSeconds(4);

            foreach(so_IEffect effect in abilityToUse.effects)
            {
                scr_EncounterEnemyCharacter enemy = GameObject.FindObjectOfType<scr_EncounterEnemyCharacter>();
                enemy.currentHealth -= effect.damage;
                enemy.UpdateHealth();
            }
            TakeTurn();
        }
    }

    public override void Die()
    {
        encounterUI.LosePanel.SetActive(true);
    }
}
