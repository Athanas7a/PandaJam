using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerAdvance : MonoBehaviour
{
    float pos;
    public Transform target;
    private Vector3 offset;
    public float x;
    public float y;
    public float z;
    // Start is called before the first frame update
    void Start()
    {
        pos = gameObject.transform.localPosition.y;
        offset = new Vector3(target.position.x - 2f, target.position.y + 2f, target.position.z - 6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Horizontal") * 3f, Vector3.up) * offset;

        transform.position = new Vector3(target.position.x + offset.x, pos, target.position.z + offset.z); //+ offset;

        transform.LookAt(new Vector3(target.position.x + x - pos, target.position.y + y, target.position.z + z));
    }
}
