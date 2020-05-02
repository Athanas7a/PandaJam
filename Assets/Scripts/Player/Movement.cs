using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed;
    public float speedRot;
    public float forceJump;

    private Animator animator;
    private bool isGround;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * speed * Time.smoothDeltaTime);
            animator.SetBool("Run", true);
        }
        else
            animator.SetBool("Run", false);

        if (Input.GetKey(KeyCode.LeftArrow))        
            transform.Rotate(Vector3.down, speedRot);
        
        if (Input.GetKey(KeyCode.RightArrow))        
            transform.Rotate(Vector3.up, speedRot);
        

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
            isGround = true;
    }
}
