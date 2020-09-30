using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("enemyAction",1,3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enemyAction()
    {
        this.gameObject.transform.Translate(Random.Range(-6,6), 0, 0);
    }
}
