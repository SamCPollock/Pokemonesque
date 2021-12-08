using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scr_EncounterUI : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI encounterText;

    [SerializeField]
    private GameObject abilityPanel;

    [SerializeField]
    float timeBetweenCharacters = 0.1f;

    [SerializeField]
    public GameObject WinPanel;

    [SerializeField]
    public GameObject LosePanel;

    [SerializeField]
    scr_GameStateManager GameStateManager;

    scr_SceneManager sceneManager;

    //[SerializeField]
    //GameObject enemyGameObject;

    //[SerializeField]
    //so_Enemy enemyToSpawn;


    // A reference to keep track of the coroutine
    private IEnumerator animateTextCoroutineRef = null;

    void Start()
    {
        sceneManager = GameObject.FindObjectOfType<scr_SceneManager>();
        animateTextCoroutineRef = AnimateTextCoroutine("You have encountered an opponent.");
        // Animate some text to say what you encountered
        //        StartCoroutine(animateTextCoroutineRef);
        //SetUpEnemy();

    }


    //public void SetUpEnemy()
    //{
    //    scr_EncounterEnemyCharacter enemyScript = enemyGameObject.GetComponent<scr_EncounterEnemyCharacter>();
    //    enemyScript.maxHealth = enemyToSpawn.maxHealth;
    //    enemyScript.currentHealth = enemyToSpawn.maxHealth;
    //    enemyScript.abilities = enemyToSpawn.abilities;
    //    enemyScript.actionDeck = enemyToSpawn.deck;

    //    enemyGameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = enemyToSpawn.name;
    //    enemyGameObject.transform.GetChild(0).GetChild(1).GetComponent<SpriteRenderer>().sprite = enemyToSpawn.sprite;
    //}

    public IEnumerator AnimateTextCoroutine(string message)
    {
        abilityPanel.SetActive(false);


        encounterText.text = "";
        for (int currentCharacter = 0; currentCharacter < message.Length; currentCharacter++)
        {
            encounterText.text += message[currentCharacter];
            yield return new WaitForSeconds(timeBetweenCharacters);
        }
       

        yield return new WaitForSeconds(2);

        if (scr_EncounterHandler.isPlayerTurn)
        {
            abilityPanel.SetActive(true);
        }

        encounterText.text = "";
        animateTextCoroutineRef = null;    // set the reference back to null so if we want we can check if it is running. 
    }

    public void LeaveEncounter()
    {
        GameStateManager.SetOverworldState();
        WinPanel.SetActive(false);
        LosePanel.SetActive(false);
    }

    public void ReloadSave()
    {
        sceneManager.ChangeScene(1);
    }
}
