using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitController : MonoBehaviour
{
    public void shoot(Vector3 dir)
    {
        GetComponent<Rigidbody2D>().AddForce(dir);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Rigidbody2D>().isKinematic = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
