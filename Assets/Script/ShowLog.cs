using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowLog : MonoBehaviour
{
    public PlayerController controller;

    public void Run()
    {
        StartCoroutine(Message());
    }

    IEnumerator Message()
    {
        Debug.Log("やわ");
        //会話イベントが発生するとプレイヤーは静止し、会話が終わるとまた動ける
        //controller.controlEnabled = fasle;

        //ラムダ式で書かないで!!Unity道場!!
        yield return new WaitUntil(() => Input.GetButtonDown("Fire1"));
        yield return null;

        Debug.Log("ここには何もないよ");
        yield return new WaitUntil(() => Input.GetButtonDown("Fire1"));
        yield return null;

        //controller.controlEnabled = true;
    }
}
