using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;


public class PlayerBehaviour : MonoBehaviour
{
    public int maxHealth = 100;
    private float currentHealth;

    private float damage = 0;
    private float speedDamage = 0.01f;
    public HealthBar healthBar;

    [SerializeField]
    private Text _gameoverText;
    [SerializeField]
    private Text _restartText;


    // Start is called before the first frame update
    void Start()
    {
        _gameoverText.gameObject.SetActive(false);
        _restartText.gameObject.SetActive(false);
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
 //           gameObject.GetComponent<ThirdPersonUserControl>().enabled = false;
 //           gameObject.GetComponent<ThirdPersonCharacter>().enabled = false;
            gameObject.GetComponent<Animator>().enabled = false;
            GameOverSequence();
            print("DEAD");            
        }
    } 
    
    void GameOverSequence()
         {
            GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
            _gameoverText.gameObject.SetActive(true);
            _restartText.gameObject.SetActive(true);
         }

}
