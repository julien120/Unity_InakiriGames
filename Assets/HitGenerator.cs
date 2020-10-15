using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitGenerator : MonoBehaviour
{
    public GameObject[] ball= new GameObject[3];
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            // 弾（ゲームオブジェクト）の生成
            GameObject clone = Instantiate(ball[Random.Range(0,4)]) as GameObject;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldDir = ray.direction;
            // クリックした座標の取得（スクリーン座標からワールド座標に変換）
            // Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // 向きの生成（Z成分の除去と正規化）
            //Vector3 shotForward = Vector3.Scale((mouseWorldPos - transform.position), new Vector3(1, 1, 0)).normalized;

            // 弾に速度を与える
            //clone.GetComponent<Rigidbody2D>().velocity = shotForward * speed;
            clone.GetComponent<hitController>().shoot(worldDir.normalized * 20000);


        }
    }
}
