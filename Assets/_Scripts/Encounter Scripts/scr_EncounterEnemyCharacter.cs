using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_EncounterEnemyCharacter : ICharacter
{

    public List<int> actionDeck;

    public List<int> discardDeck;

    public scr_EncounterUI encounterUI;

    private bool hasTakeTurn = false;

    public Animator effectsAnimator;

    private scr_SoundEffects soundEffectsManager;

    [SerializeField]
    private scr_DamageText playerDamageText;


    public override void TakeTurn()
    {
        //Debug.Log("ENEMY PASSED THEIR TURN");
        Shuffle(actionDeck);
        UseAbility(Draw(actionDeck));

        //scr_EncounterHandler.PassTurn();
    }

    // Start is called before the first frame update
    void Start()
    {
        encounterUI = GameObject.Find("State_Encounter").GetComponent<scr_EncounterUI>();
        Initialize();
        soundEffectsManager = GameObject.FindObjectOfType<scr_SoundEffects>();

    }

    public void Initialize()
    {
        UpdateHealth();

    }

    // Update is called once per frame
    void Update()
    {
        if (scr_EncounterHandler.isPlayerTurn == false && hasTakeTurn == false && currentHealth > 0)
        {
            hasTakeTurn = true;
            Invoke("TakeTurn", 1);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("Before shuffle: " + string.Join(", ", actionDeck));
            Shuffle(actionDeck);
            Debug.Log("After shuffle: " + string.Join(", ", actionDeck));
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            Draw(actionDeck);
        }

    }

    public void Shuffle<T>(List<T> inputList)
    {
        for (int i = 0; i < inputList.Count - 1; i++)
        {
            T temp = inputList[i];
            int rand = Random.Range(1, inputList.Count);
            inputList[i] = inputList[rand];
            inputList[rand] = temp;
        }
    }

    int Draw(List<int> inputList)
    {
        int temp = inputList[0];
        inputList.RemoveAt(0);

        discardDeck.Add(temp);

        if (inputList.Count == 0)
        {
            for (int i = 0; i < discardDeck.Count; i++)
            {

                inputList.Add(discardDeck[i]);
            }
            Shuffle(inputList);
            discardDeck.Clear();
            
        }

        return temp;

    }

    void UseAbility(int abilitySlot)
    {
        
        StartCoroutine(encounterUI.AnimateTextCoroutine(abilities[abilitySlot].abilityText));
        scr_EncounterPlayerCharacter player = GameObject.FindObjectOfType<scr_EncounterPlayerCharacter>();
        float startingHealth = player.currentHealth;
        foreach (so_IEffect effect in abilities[abilitySlot].effects)
        {
            player.currentHealth -= effect.baseDamage;                      // Raw damage
            player.currentHealth -= (effect.strengthScaling * strength);    // StrengthScaling damage
            if (effect.damageRoll > 0)
                player.currentHealth -= Random.Range(1, effect.damageRoll);     // Roll damage
            player.strength -= effect.debuff;                               // Apply Debuff to opponent
            strength += effect.buff;                                        // Apply Buff to self    
        }

        switch (abilities[abilitySlot].name)
        {
            case "Scratch":
                effectsAnimator.SetTrigger("boostTrigger");
                soundEffectsManager.PlaySound(2);
                break;
            case "Screech":
                effectsAnimator.SetTrigger("airTrigger");
                soundEffectsManager.PlaySound(3);
                break;
            case "Sniff":
                effectsAnimator.SetTrigger("splashTrigger");
                soundEffectsManager.PlaySound(4);
                break;
            case "Bite":
                effectsAnimator.SetTrigger("bloodTrigger");
                soundEffectsManager.PlaySound(5);
                break;
        }

        float endHealth = player.currentHealth;
        int damageDealt = (int)(startingHealth - endHealth);

        playerDamageText.ShowDamage(damageDealt);

        player.UpdateHealth();

        scr_EncounterHandler.PassTurn();
        hasTakeTurn = false;
    }

    public override void Die()
    {
        encounterUI.WinPanel.SetActive(true);
        GrantAbilityToPlayer();
    }

    public void GrantAbilityToPlayer()
    {
        scr_EncounterPlayerCharacter player = GameObject.FindObjectOfType<scr_EncounterPlayerCharacter>();
        player.abilities.Add(abilities[0]);
        Debug.Log("Granting player ability: " + abilities[0].name);
    }

    // shuffler: 
    /*
    For each ability in the ability array: 
    Add an instance of it to my shuffler deck. 
    shuffle my deck. 

    on "draw"
    take the top value from my deck. 
    Use the ability associated. 
    Remove the top value from my shuffler. 
    Add it to "Discard" pile. 

    When nothing remains in my deck, move everything from discard to deck. 
    Shuffle deck. 

     */
}
