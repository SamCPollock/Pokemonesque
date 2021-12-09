using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    private Rigidbody2D rb;

    private scr_SoundEffects soundEffectsManager;

    private scr_GameStateManager gameStateManager;

    [Header("RandomEncounters")]
    public bool isInRandomEncounterTrigger;
    public float randomEncounterFrequency;
    public GameObject randomEncounterScreen;
    public GameObject overworld;

    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        soundEffectsManager = FindObjectOfType<scr_SoundEffects>();
        gameStateManager = GameObject.FindObjectOfType<scr_GameStateManager>();
    }

    void Update()
    {
        float moveValue = moveSpeed * Time.deltaTime;
        // move the player 
        //transform.position += new Vector3(Input.GetAxis("Horizontal") * moveValue, Input.GetAxis("Vertical") * moveValue, 0f);
        rb.AddForce(new Vector3(Input.GetAxis("Horizontal") * moveValue, Input.GetAxis("Vertical") * moveValue, 0f));

    }

    private void FixedUpdate()
    {
        if (rb.velocity != Vector2.zero && isInRandomEncounterTrigger) // check for random encounter.
        {
            float randomFloat = Random.Range(0, 100);
            if (randomFloat < randomEncounterFrequency)
            {
                Debug.Log("TIME FOR A RANDOM BATTLE!");
                gameStateManager.SetEncounterState();
                //randomEncounterScreen.SetActive(true);
                //overworld.SetActive(false);
                

            }
            
            // make random with badluck prevention. Random determines if random encounter begins. 
        }
    }

    public void PlayFootStepSound()
    {
        if (isInRandomEncounterTrigger)
        {
            soundEffectsManager.PlaySound(1);
        }
        else
        {
            soundEffectsManager.PlaySound(0);
        }
    }
}
