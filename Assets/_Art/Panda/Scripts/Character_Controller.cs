using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator))]
public class Character_Controller : MonoBehaviour
{
    private Vector3 inputVector;
    public float speed = 2;
    public float forceJump = 5;
    private Animator animator;
    private bool isGround;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.z = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && isGround){
            
            GetComponent<Rigidbody>().AddForce(Vector3.up * forceJump, ForceMode.Force);

            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

        if(inputVector.magnitude > 0.2)
        {
            inputVector *= 5;
            inputVector = inputVector.normalized;
            transform.forward = inputVector;
            transform.Translate(inputVector * speed * Time.deltaTime, Space.World);

            animator.SetBool("Run", true);

        }
        else
        {
            animator.SetBool("Run", false);
        }

       //transform.forward = inputVector;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("ground"))
        {
            isGround = true;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("ground"))
        {
            isGround = false;
        }
    }
}
