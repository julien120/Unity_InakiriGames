using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steak : MonoBehaviour
{
    //[SerializeField]
    //AudioClip getSe = null;
    //bool get = false;
    SoundManager soundManager;


    //protected override void Start()
    //{
    //    base.start();
    //    soundManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SoundManager>();
    //}
    //public override void GetItem() {
    //    if (get)
    //    {
    //        return;
    //    }
    //    get = true; //取得済みフラグをONにする
    //    gameManager.CorrectedCoins++;   //集めたコインの数を1つ増やす
    //    //SEが設定されていたら音を鳴らす
    //    if (getSe != null)
    //    {
    //        soundManager.PlaySeByName(getSe.name);
    //    }
    //    DestroyItem();
    //}
    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        GetItem();
    //    }
    //}

}
