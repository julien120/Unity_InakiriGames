using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    Rigidbody2D rigid2d;
    // Start is called before the first frame update
    void Start()
    {
        rigid2d = this.gameObject.GetComponent<Rigidbody2D>();
        InvokeRepeating("enemyAction",1,3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enemyAction()
    {
        //こっちの方が自然の動き
        this.rigid2d.AddForce(transform.right * Random.Range(-3, 3) * 30.0f);
        //this.gameObject.transform.Translate(Random.Range(-3,3), 0, 0);
    }
}
