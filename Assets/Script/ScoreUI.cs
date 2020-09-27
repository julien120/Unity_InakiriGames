using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public int steakCount;
    public Text steakUI;
    public Text rankCountUI;
    int rank;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        steakUI.text = "肉マイレージ数：" + steakCount.ToString("f0") + "g";
        rank = (int)(10000000/steakCount*0.8);
        rankCountUI.text = "肉マイレージ総合ランキング：" + rank + "位";

    }

    
}
