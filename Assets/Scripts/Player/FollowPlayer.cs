using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    float pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = gameObject.transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        //working success as child
       transform.position = new Vector3(transform.position.x, pos, transform.position.z);

    }
   
}
