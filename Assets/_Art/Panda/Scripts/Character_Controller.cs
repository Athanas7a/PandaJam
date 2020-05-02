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

        if (Input.GetKeyDown(KeyCode.Space)){
            print("JUMP!");
            GetComponent<Rigidbody>().AddForce(Vector3.up * forceJump, ForceMode.Force);
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
}
