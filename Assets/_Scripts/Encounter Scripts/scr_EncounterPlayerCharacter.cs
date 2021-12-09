using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_EncounterPlayerCharacter : ICharacter
{

    private GameObject abilitiesPanel;
    public GameObject abilityButtonPrefab;
    public scr_EncounterUI encounterUI;
    public Animator effectsAnimator;
    public Animator myAnimator;
    private scr_SoundEffects soundEffectsManager;


    [SerializeField]
    private scr_DamageText enemyDamageText;

    public override void TakeTurn()
    {
        scr_EncounterHandler.PassTurn();
    }

    void Start()
    {
        abilitiesPanel = GameObject.Find("AbilitiesPanel");
        encounterUI = GameObject.Find("State_Encounter").GetComponent<scr_EncounterUI>();
        soundEffectsManager = GameObject.FindObjectOfType<scr_SoundEffects>();

        InitializePlayer();
    }

    private void OnEnable()
    {
        InitializePlayer();
    }

    void InitializePlayer()
    {
        
        foreach (Transform child in abilitiesPanel.transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        if (abilities.Count > 4)
        {
            abilities.RemoveAt(0);
        }

        foreach (so_Ability ability in abilities)
        {
            GameObject newButton = Instantiate(abilityButtonPrefab, abilitiesPanel.transform);
            newButton.GetComponentInChildren<Text>().text = ability.name;
            newButton.GetComponent<Button>().onClick.AddListener(() => UseAbility(ability));
            newButton.GetComponent<scr_MouseOver>().mouseOverText = ability.description;
        }

        UpdateHealth();
    }

    public void UseAbility(so_Ability abilityToUse)
    {

        if (scr_EncounterHandler.isPlayerTurn)
        {

            myAnimator.SetTrigger("wiggleTrigger");
            StartCoroutine(encounterUI.AnimateTextCoroutine(abilityToUse.abilityText));
            //yield return new WaitForSeconds(4);
            scr_EncounterEnemyCharacter enemy = GameObject.FindObjectOfType<scr_EncounterEnemyCharacter>();
            float startingHealth = enemy.currentHealth;

            foreach (so_IEffect effect in abilityToUse.effects)
            {
                enemy.currentHealth -= effect.baseDamage;                      // Raw damage
                enemy.currentHealth -= (effect.strengthScaling * strength);    // StrengthScaling damage
                if (effect.damageRoll > 0)
                    enemy.currentHealth -= Random.Range(1, effect.damageRoll);     // Roll damage

                enemy.strength -= effect.debuff;                               // Apply Debuff to opponent
                strength += effect.buff;                                       // Apply Buff to self
            }

            switch (abilityToUse.name)
            {
                case "Power Up":
                    effectsAnimator.SetTrigger("boostTrigger");
                    soundEffectsManager.PlaySound(2);
                    break;
                case "Screech":
                    effectsAnimator.SetTrigger("airTrigger");
                    soundEffectsManager.PlaySound(3);
                    break;
                case "Drench":
                    effectsAnimator.SetTrigger("splashTrigger");
                    soundEffectsManager.PlaySound(4);
                    break;
                case "Bite":
                    effectsAnimator.SetTrigger("bloodTrigger");
                    soundEffectsManager.PlaySound(5);
                    break;
            }


            float endHealth = enemy.currentHealth;

            int damageDealt = (int)(startingHealth - endHealth);
            enemyDamageText.ShowDamage(damageDealt);



            enemy.UpdateHealth();


            TakeTurn();
        }
    }

    public override void Die()
    {
        encounterUI.LosePanel.SetActive(true);
    }
}
