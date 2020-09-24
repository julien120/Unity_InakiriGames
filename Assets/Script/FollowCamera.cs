using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//リファレンス読む
[RequireComponent(typeof(Camera))]
public class FollowCamera : MonoBehaviour
{
    GameObject playerObj;
    PlayerController player;
    Transform playerTransform;

    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<PlayerController>();
        playerTransform = playerObj.transform;
    }
    void LateUpdate()
    {
        MoveCamera();
    }
    void MoveCamera()
    {
        //横方向だけ追従
        //カメラのpositionにゲームオブジェクトPlayerの座標を代入する
        transform.position = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
    }
}
