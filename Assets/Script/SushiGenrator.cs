using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiGenrator : MonoBehaviour
{
    public Vector3 middle = new Vector3(40.4f, 1f, 0);
    public GameObject[] sushi = new GameObject[3];

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LaunchProjectile", 2.0f, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % 180 == 0)
        {

           // Instantiate(sushi[Random.Range(0, 3)], middle, Quaternion.identity);
        }
    }

    void LaunchProjectile()
    {

        Instantiate(sushi[Random.Range(0, 3)], middle, Quaternion.identity);


    }
}
