using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;


public class PlayerBehaviour : MonoBehaviour
{
    public int maxHealth = 500;
    private float currentHealth;

    private float damage = 0;
    public float speedDamage = 0.01f;
    public HealthBar healthBar;

    [SerializeField]
    private Text _gameoverText;
    [SerializeField]
    private Text _restartText;

    //Movement
    public float speed;
    public float speedRot;
    public float forceJump;
    public float characterRotationSpeed;

    private Animator animator;
    private bool isGround;
    private bool isVictory;
    private float timer = 0;

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

        GameVictory();

       // if (Input.GetKeyDown(KeyCode.P))
        //{
           // animator.SetBool("Win", true);
       // }

    }

    private void TakeDamage()
    {
        if (!isVictory)
        {

            timer += Time.deltaTime;

            if (timer > 0.1f)
            {
                timer = 0;
                damage = 0;
            }

            if (healthBar.slider.value > 0)
            {
 //               damage += Time.smoothDeltaTime * speedDamage;
                damage += speedDamage;
                currentHealth -= damage;
                healthBar.setHealth(currentHealth);

            }
        }
    }
    public void AddHealth(int bonusHealth) {
        
        currentHealth += bonusHealth;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthBar.setHealth(currentHealth);
    }  

    private void Dead() {
        if (healthBar.slider.value <= 0)
        {
            //gameObject.GetComponent<Animator>().enabled = false;
            GameOverSequence();
            animator.SetBool("Dead", true);
            print("DEAD");

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
            }
        }



    }
    private void Movement() 
    {
        if (Input.GetKey(KeyCode.UpArrow) && healthBar.slider.value > 0.1f && !isVictory )
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

    public void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.tag.Equals("Goal"))
            isVictory = true;
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

    private void GameVictory()
    {
        if (isVictory == true)
        {
            //if (gameObject.transform.GetChild(0).rotation.y <= 0.5f)
            //{
            //    print("Rotation");
            //    gameObject.transform.GetChild(0).Rotate(Vector3.up * 10);
            //}

            if (gameObject.transform.GetChild(0).localRotation.eulerAngles.y < 180)
                gameObject.transform.GetChild(0).Rotate(Vector3.up * characterRotationSpeed * Time.smoothDeltaTime);
            else
            {
                animator.SetBool("Win", true);
                _restartText.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.R))
                {
                    SceneManager.LoadScene("Scene01");
                }

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    SceneManager.LoadScene(0);
                }
            }

            print("Vicrtory");
        }
    }

}
