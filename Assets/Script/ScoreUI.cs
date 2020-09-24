using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public int steakCount;
    public Text steakUI;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        steakUI.text = "肉マイレージ数：" + steakCount.ToString("f0") + "g";
    }

    public void count()
    {
        Debug.Log("SendMessageメソッド使えてる！");
        //steakUI.text = "肉マイレージ数：" + steakCount.ToString("f0") + "g";
    }
}
