using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scr_EnemySpawner : MonoBehaviour
{
    [SerializeField]
    so_Enemy[] possibleEnemies;

    [SerializeField]
    so_Enemy enemyToSpawn;

    [SerializeField]
    GameObject enemyGameObject;

    [SerializeField]

    void Start()
    {
        SetUpEnemy();

    }

    public void SetUpEnemy()
    {
        int randomInt = Random.Range(0, possibleEnemies.Length);
        enemyToSpawn = possibleEnemies[randomInt];

        Debug.Log("Spawning: " + enemyToSpawn);

        scr_EncounterEnemyCharacter enemyScript = enemyGameObject.GetComponent<scr_EncounterEnemyCharacter>();
        enemyScript.maxHealth = enemyToSpawn.maxHealth;
        enemyScript.currentHealth = enemyToSpawn.maxHealth;
        enemyScript.abilities = enemyToSpawn.abilities;
        enemyScript.actionDeck.Clear();
        for (int i = 0; i < enemyToSpawn.deck.Count; i++)
        {
            enemyScript.actionDeck.Add(enemyToSpawn.deck[i]);
        }
        //enemyScript.actionDeck = enemyToSpawn.deck;
        enemyScript.strength = enemyToSpawn.strength;
        enemyScript.Initialize();

        enemyGameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = enemyToSpawn.name;
        enemyGameObject.transform.GetChild(1).GetComponent<Image>().sprite = enemyToSpawn.sprite;
    }
}
