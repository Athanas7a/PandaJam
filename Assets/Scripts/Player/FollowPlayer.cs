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
        //print(GameObject.FindGameObjectWithTag("ground").GetComponent);
       /* if (gameObject.transform.position.y - gameObject.transform.parent.position.y < pos )
        {
            pos += gameObject.transform.position.y - gameObject.transform.parent.position.y;
        }*/
        //working success as child
       transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

    }
   
}
