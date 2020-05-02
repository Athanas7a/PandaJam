using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionItems : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Pill"))
        {
            Destroy(collision.gameObject);
            print("Pill collected");
        }

        if (collision.gameObject.tag.Equals("Food"))
        {
            Destroy(collision.gameObject);
            print("Food collected");
        }

        if (collision.gameObject.tag.Equals("Speedup"))
        {
            Destroy(collision.gameObject);
            print("Speed booster collected");
            // TOADD: speed up + down
        }


    }


}
