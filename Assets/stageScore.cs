using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stageScore : MonoBehaviour
{
    public Text ScoreText;
    public Text ScoreGram;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "肉マイレージ総合ランキング：" + ScoreUI.rank + "位";
       ScoreGram.text = "肉マイレージ数：" + ScoreUI.steakCount.ToString("f0") + "g";
    }
}
