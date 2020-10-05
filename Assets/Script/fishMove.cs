using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class fishMove : MonoBehaviour
{
    //public Transform goal;          //目的地となるオブジェクトのトランスフォーム格納用
    // private NavMeshAgent agent;     //エージェントとなるオブジェクトのNavMeshAgent格納用

   // public Vector3[] waypoint = new Vector3[4];
    public GameObject[] waypoint = new GameObject[4];
   // private Rigidbody2D rb = null;
    int count = 0;
    GameObject target;
    //Public 型[] 変数名 = new 型名[5];
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("waypoint");
        //rb = GetComponent<Rigidbody2D>();
        // rb.velocity = new Vector2(xSpeed, rb.velocity.y);
       // transform.position = Vector2.MoveTowards(transform.position, waypointt[0].transform.position, 5 * Time.deltaTime);

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, waypoint[count].transform.position, 10 * Time.deltaTime);
        

    }

  
    private void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("判定");
        if (coll.gameObject.CompareTag("waypointCollider"))
        {
           Debug.Log("wayポイント更新" + count);
            transform.position = Vector2.MoveTowards(transform.position, waypoint[count].transform.position, 10 * Time.deltaTime);
         
            // count++;
            Debug.Log("wayポイント更新" + count);
        }
    }
}
