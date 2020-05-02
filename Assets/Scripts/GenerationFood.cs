using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationFood : MonoBehaviour
{
    public GameObject food;
    public List<GameObject> pointFood;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject obj in pointFood)
        {
            Instantiate(food, obj.transform.position, Quaternion.identity, gameObject.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
