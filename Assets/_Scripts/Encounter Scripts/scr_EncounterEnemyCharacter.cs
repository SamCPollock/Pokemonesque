using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_EncounterEnemyCharacter : ICharacter
{

    public List<int> actionDeck;

    public List<int> discardDeck;

    public scr_EncounterUI encounterUI;

    private bool hasTakeTurn = false;


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

    }

    // Update is called once per frame
    void Update()
    {
        if (scr_EncounterHandler.isPlayerTurn == false && hasTakeTurn == false)
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

    void Shuffle<T>(List<T> inputList)
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
        
        Debug.Log("Enemy using ability: " + abilities[abilitySlot]);
        StartCoroutine(encounterUI.AnimateTextCoroutine(abilities[abilitySlot].abilityText));
        scr_EncounterHandler.PassTurn();
        hasTakeTurn = false;
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
