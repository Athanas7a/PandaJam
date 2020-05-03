using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;


public class PlayerBehaviour : MonoBehaviour
{
    public int maxHealth = 500;
    private float currentHealth;

    private float damage = 0;
    private float speedDamage = 0.01f;
    public HealthBar healthBar;

    [SerializeField]
    private Text _gameoverText;
    [SerializeField]
    private Text _restartText;

    //Movement
    public float speed;
    public float speedRot;
    public float forceJump;

    private Animator animator;
    private bool isGround;

    // Start is called before the first frame update
    void Start()
    {
        _gameoverText.gameObject.SetActive(false);
        _restartText.gameObject.SetActive(false);
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);


        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

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
            gameObject.GetComponent<Animator>().enabled = false;
            GameOverSequence();
            print("DEAD");            
        }
    }
    private void Movement() 
    {
        if (Input.GetKey(KeyCode.UpArrow) && healthBar.slider.value > 0.1f)
        {
            transform.Translate(Vector3.forward * speed * Time.smoothDeltaTime);
            animator.SetBool("Run", true);
        }
        else
            animator.SetBool("Run", false);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.down, speedRot * Time.smoothDeltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Rotate(Vector3.up, speedRot * Time.smoothDeltaTime);


        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            animator.SetBool("Jump", true);
            GetComponent<Rigidbody>().AddForce(Vector3.up * forceJump, ForceMode.Force);
        }
        else
            animator.SetBool("Jump", false);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("ground"))
            isGround = true;
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("ground"))
            isGround = false;
    }

    private void GameOverSequence()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
        _gameoverText.gameObject.SetActive(true);
        _restartText.gameObject.SetActive(true);
    }

}
