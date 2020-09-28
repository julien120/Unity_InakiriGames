using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    //これまでpublicで変数宣言してきたが極力Findを用いてオブジェクト操作した方が好ましいのか？
    GameObject startBtn;


    // Start is called before the first frame update
    void Start()
    {
        this.startBtn = GameObject.Find("startButton");
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void btn()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
