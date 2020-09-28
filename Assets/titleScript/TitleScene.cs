using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    //これまでpublicで変数宣言してきたが極力Findを用いてオブジェクト操作した方が好ましいのか？
    GameObject startBtn;
    public GameObject howToPlayImage;



    // Start is called before the first frame update
    void Start()
    {
        this.startBtn = GameObject.Find("startButton");
        //SetActiveでfalse/true切り替えする場合はFindで探せないからComponentで
        //this.howToPlayImage = GameObject.Find("howtoplayImage");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            howToPlayImage.SetActive(false);
        }
    }

    public void btn()
    {
        //インスペクタ上でOnClick操作をするがスクリプトからButtonクリックでscene変遷できないか？

        SceneManager.LoadScene("SampleScene");
    }

    public void howbtn()
    {
        howToPlayImage.SetActive(true);
       

    }


}
