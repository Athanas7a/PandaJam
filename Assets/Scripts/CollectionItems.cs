using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionItems : MonoBehaviour
{
    public int bonusHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {        

        if (collision.gameObject.tag.Equals("Food"))
        {
            GetComponent<PlayerBehaviour>().AddHealth(bonusHealth);//healthBar.addHealth(20);
            Destroy(collision.gameObject);
            print("Food collected");
        }
        /*
        if (collision.gameObject.tag.Equals("Speedup"))
        {
            Destroy(collision.gameObject);
            print("Speed booster collected");
            // TOADD: speed up + down
        }*/


    }


}
