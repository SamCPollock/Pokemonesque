using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ICharacter : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public float strength;


    [SerializeField]
    protected GameObject healthBar;

    [Header("Abilities")]
    public List <so_Ability> abilities;
    public abstract void TakeTurn();

    public void UpdateHealth()
    {
        healthBar.GetComponent<Slider>().value = this.currentHealth / this.maxHealth;
        Debug.Log("Maxhealth =  " + maxHealth + " currentHealth = " + currentHealth);

        //Debug.Log("Setting healthbar to: " + this.currentHealth / this.maxHealth);

        if (currentHealth <= 0)
        {
            // Die
            Die();
            Debug.Log(gameObject.name + " Has DIED");
        }
    }

    public abstract void Die();


}
