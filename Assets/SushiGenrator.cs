using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiGenrator : MonoBehaviour
{
    public GameObject[] sushi = new GameObject[3];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 180 == 0)
        {
           
            Instantiate(sushi[Random.Range(0,3)]);
        }
    }
}
