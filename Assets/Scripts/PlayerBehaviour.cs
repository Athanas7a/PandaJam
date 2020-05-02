using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerBehaviour : MonoBehaviour
{
    public int maxHealth = 100;
    private float currentHealth;

    private float damage = 0;
    private float speedDamage = 0.01f;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        TakeDamage();

        Dead();
    }

    private void TakeDamage()
    {
        if (healthBar.slider.value>0)
        {
            damage += Time.smoothDeltaTime * speedDamage;
            currentHealth -= damage;
            healthBar.setHealth(currentHealth);
        }
    }
    public void AddHealth(int bonusHealth) {
        currentHealth += bonusHealth;
        healthBar.setHealth(currentHealth);
    }  

    private void Dead() {
        if (healthBar.slider.value <= 0)
        {
            gameObject.GetComponent<ThirdPersonUserControl>().enabled = false;
            gameObject.GetComponent<ThirdPersonCharacter>().enabled = false;
            gameObject.GetComponent<Animator>().enabled = false;
            print("DEAD");            
        }
    }
}
