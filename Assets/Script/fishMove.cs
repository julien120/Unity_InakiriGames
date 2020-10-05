using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class fishMove : MonoBehaviour
{
    //public Transform goal;          //目的地となるオブジェクトのトランスフォーム格納用
    // private NavMeshAgent agent;     //エージェントとなるオブジェクトのNavMeshAgent格納用

    public Vector3[] waypoint = new Vector3[4];
    public GameObject[] waypointt = new GameObject[4];
    private Rigidbody2D rb = null;
    int count = 0;
    //Public 型[] 変数名 = new 型名[5];
    // Start is called before the first frame update
    void Start()
    {
        //エージェントのNaveMeshAgentを取得する
        //agent = GetComponent<NavMeshAgent>();
        //目的地となる座標を設定する
        // agent.destination = goal.position;
        rb = GetComponent<Rigidbody2D>();
        // rb.velocity = new Vector2(xSpeed, rb.velocity.y);
        transform.position = Vector2.MoveTowards(transform.position, waypointt[0].transform.position, 5 * Time.deltaTime);

    }

    // Update is called once per frame
    void Update()
    {
        //↓座標を変更してるから秒で移動する
        //this.gameObject.transform.position = waypointt[0].transform.position;
        if (this.gameObject.transform.position == waypointt[count].transform.position) {
            count++;
            transform.position = Vector2.MoveTowards(transform.position,waypointt[0].transform.position,5*Time.deltaTime);
      
        }
        //tranlateでも瞬間移動ざむらい
        //  this.gameObject.transform.Translate(this.waypointt[0].transform.position); //移動
        //this.waypointt[0].transform.position *= 0.028f; //減速

    }
}
